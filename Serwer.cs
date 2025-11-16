using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Statki
{
    public partial class Serwer : Form
    {
        private TcpListener listener;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        private bool jaGotowy = false;
        private bool przeciwnikGotowy = false;

        // opcje gry
        private int[,] mojePlansza = new int[10, 10]; // 0=puste, 1=statek, 2=trafiony, 3=pudło
        private int[,] planszaPrzeciwnika = new int[10, 10]; 
        private Button[,] mojePrzyciski = new Button[10, 10];
        private Button[,] przyciskiPrzeciwnika = new Button[10, 10];
        private bool mojaTura;
        private int czasGrySekundy = 0;
        
        private enum FazaGry { Ustawianie, Gra, Koniec }
        private FazaGry fazaGry = FazaGry.Ustawianie;
        
        // opcje statkow
        private List<int> statkiDoUstawienia = new List<int> { 4, 3, 3, 2, 2, 1, 1};
        private int aktualnyStatek = 0;
        private bool poziomo = true; 
        
        // liczniki
        private int mojeTrafioneStatki = 0;
        private int statkiPrzeciwnikaTrafione = 0;
        private int WSZYSTKIE_POLA_STATKOW => statkiDoUstawienia.Sum();

        public Serwer()
        {
            InitializeComponent();
            buttonStop.Enabled = false;
            buttonWyslij.Enabled = false;
            buttonStart.Enabled = false;

            lblTura.Hide();
            lblStatus.Hide();
            lblCzasGry.Hide();
            buttonPoddaj.Hide();
            buttonOrientacja.Hide();

            txtAdres.Text = "127.0.0.1";
            txtPort.Text = "9000";
            
            InicjalizujPlansze();
        }

        private void InicjalizujPlansze()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    mojePrzyciski[i, j] = new Button();
                    mojePrzyciski[i, j].Size = new Size(35, 35);
                    mojePrzyciski[i, j].Location = new Point(j * 35, i * 35);
                    mojePrzyciski[i, j].BackColor = Color.LightBlue;
                    mojePrzyciski[i, j].Tag = new Point(i, j);
                    mojePrzyciski[i, j].Click += MojaPlanszaKlik;
                    mojePrzyciski[i, j].Font = new Font("Arial", 8, FontStyle.Bold);
                    panelMojaPlanszy.Controls.Add(mojePrzyciski[i, j]);
                    
                    przyciskiPrzeciwnika[i, j] = new Button();
                    przyciskiPrzeciwnika[i, j].Size = new Size(35, 35);
                    przyciskiPrzeciwnika[i, j].Location = new Point(j * 35, i * 35);
                    przyciskiPrzeciwnika[i, j].BackColor = Color.LightGray;
                    przyciskiPrzeciwnika[i, j].Tag = new Point(i, j);
                    przyciskiPrzeciwnika[i, j].Click += PlanszaPrzeciwnikaKlik;
                    przyciskiPrzeciwnika[i, j].Enabled = false;
                    przyciskiPrzeciwnika[i, j].Font = new Font("Arial", 12, FontStyle.Bold);
                    panelPlanszaPrzeciwnika.Controls.Add(przyciskiPrzeciwnika[i, j]);
                    
                    mojePlansza[i, j] = 0;
                    planszaPrzeciwnika[i, j] = 0;
                }
            }
        }

        private void MojaPlanszaKlik(object sender, EventArgs e)
        {
            if (fazaGry != FazaGry.Ustawianie || aktualnyStatek >= statkiDoUstawienia.Count) 
                return;
                
            Button btn = sender as Button;
            Point pos = (Point)btn.Tag;
            int rozmiar = statkiDoUstawienia[aktualnyStatek];
            
            if (CzyMoznaUstawicStatek(pos.X, pos.Y, rozmiar, poziomo))
            {
                UstawStatek(pos.X, pos.Y, rozmiar, poziomo);
                aktualnyStatek++;
                
                if (aktualnyStatek < statkiDoUstawienia.Count)
                {
                    lblStatus.Text = $"Ustaw statek o rozmiarze: {statkiDoUstawienia[aktualnyStatek]}";
                }
                else
                {
                    lblStatus.Text = "Statki ustawione. Czekam na przeciwnika...";
                    buttonOrientacja.Hide();
                    jaGotowy = true;
                    WyslijWiadomosc("GOTOWY");
                    
                    if (przeciwnikGotowy)
                    {
                        RozpocznijGre();
                    }
                }
            }
        }

        private bool CzyMoznaUstawicStatek(int x, int y, int rozmiar, bool czyPoziomo)
        {
            if (czyPoziomo)
            {
                if (y + rozmiar > 10) return false;
            }
            else
            {
                if (x + rozmiar > 10) return false;
            }
            
            for (int i = 0; i < rozmiar; i++)
            {
                int checkX = czyPoziomo ? x : x + i;
                int checkY = czyPoziomo ? y + i : y;
                
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int nx = checkX + dx;
                        int ny = checkY + dy;
                        
                        if (nx >= 0 && nx < 10 && ny >= 0 && ny < 10)
                        {
                            if (mojePlansza[nx, ny] == 1) return false;
                        }
                    }
                }
            }
            
            return true;
        }

        private void UstawStatek(int x, int y, int rozmiar, bool czyPoziomo)
        {
            for (int i = 0; i < rozmiar; i++)
            {
                int posX = czyPoziomo ? x : x + i;
                int posY = czyPoziomo ? y + i : y;
                
                mojePlansza[posX, posY] = 1;
                mojePrzyciski[posX, posY].BackColor = Color.DarkGray;
                mojePrzyciski[posX, posY].Text = "■";
            }
        }

        private void PlanszaPrzeciwnikaKlik(object sender, EventArgs e)
        {
            if (fazaGry != FazaGry.Gra || !mojaTura) 
                return;
                
            Button btn = sender as Button;
            Point pos = (Point)btn.Tag;
            
            if (planszaPrzeciwnika[pos.X, pos.Y] != 0) 
                return;
            
            WyslijWiadomosc($"STRZAL:{pos.X}:{pos.Y}");
            mojaTura = false;
            AktualizujInterfejs();
        }

        private void RozpocznijGre()
        {
            fazaGry = FazaGry.Gra;
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    przyciskiPrzeciwnika[i, j].Enabled = true;
                }
            }
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mojePrzyciski[i, j].Enabled = false;
                }
            }
            
            mojaTura = true;
            lblTura.Show();
            lblCzasGry.Show();
            buttonPoddaj.Show();
            lblStatus.Text = "Gra rozpoczęta!";
            
            timerGry.Start();
            AktualizujInterfejs();
        }

        private void AktualizujInterfejs()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => AktualizujInterfejs()));
                return;
            }
            
            if (fazaGry == FazaGry.Gra)
            {
                lblTura.Text = mojaTura ? "TWOJA TURA" : "TURA PRZECIWNIKA";
                lblTura.ForeColor = mojaTura ? Color.Green : Color.Red;
                
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (planszaPrzeciwnika[i, j] == 0) 
                        {
                            przyciskiPrzeciwnika[i, j].Enabled = mojaTura;
                        }
                    }
                }
            }
        }

        private void Log(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => Log(message)));
                return;
            }
            txtLog.AppendText(message + Environment.NewLine);
        }

        private async void buttonDolacz_Click(object sender, EventArgs e)
        {
            try
            {
                int port = int.Parse(txtPort.Text);
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Log("Serwer uruchomiony. Oczekiwanie na klienta...");

                buttonDolacz.Enabled = false;
                buttonStop.Enabled = true;
                txtAdres.Enabled = false;
                txtPort.Enabled = false;

                client = await listener.AcceptTcpClientAsync();
                Log("Klient połączony!");

                NetworkStream stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };

                buttonWyslij.Enabled = true;
                lblStatus.Show();
                lblStatus.Text = $"Ustaw statek o rozmiarze: {statkiDoUstawienia[aktualnyStatek]}";
                buttonOrientacja.Show();

                await Task.Run(() => ListenForMessages());
            }
            catch (FormatException)
            {
                Log("Błąd: Port musi być liczbą.");
            }
            catch (Exception ex)
            {
                Log($"Błąd: {ex.Message}");
            }
        }

        private void ListenForMessages()
        {
            try
            {
                while (client != null && client.Connected)
                {
                    string message = reader.ReadLine();
                    if (message != null)
                    {
                        OdbierzWiadomosc(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Błąd odbioru: {ex.Message}");
            }
        }

        private void OdbierzWiadomosc(string message)
        {
            this.Invoke(new Action(() =>
            {
                if (message == "GOTOWY")
                {
                    Log("Przeciwnik gotowy");
                    przeciwnikGotowy = true;
                    
                    if (jaGotowy && przeciwnikGotowy)
                    {
                        RozpocznijGre();
                    }
                }
                else if (message.StartsWith("STRZAL:"))
                {
                    string[] parts = message.Split(':');
                    int x = int.Parse(parts[1]);
                    int y = int.Parse(parts[2]);
                    
                    ObsluzStrzalPrzeciwnika(x, y);
                }
                else if (message.StartsWith("WYNIK:"))
                {
                    string[] parts = message.Split(':');
                    int x = int.Parse(parts[1]);
                    int y = int.Parse(parts[2]);
                    bool trafiony = parts[3] == "TRAFIONY";
                    bool zatopiony = parts.Length > 4 && parts[4] == "ZATOPIONY";
                    
                    ObsluzWynikStrzalu(x, y, trafiony, zatopiony);
                }
                else if (message == "PODDAJ")
                {
                    fazaGry = FazaGry.Koniec;
                    timerGry.Stop();
                    PokazZwyciestwo();
                    Log("Przeciwnik poddał sie. ZWYCIĘSTWO");
                }
                else if (message == "PRZEGRANA")
                {
                    fazaGry = FazaGry.Koniec;
                    timerGry.Stop();
                    PokazPorazke();
                }
                else
                {
                    Log($"Przeciwnik: {message}");
                }
            }));
        }

        private void ObsluzStrzalPrzeciwnika(int x, int y)
        {
            bool trafiony = mojePlansza[x, y] == 1;
            bool zatopiony = false;
            
            if (trafiony)
            {
                mojePlansza[x, y] = 2; // Trafiony
                mojePrzyciski[x, y].BackColor = Color.Red;
                mojePrzyciski[x, y].Text = "X";
                mojeTrafioneStatki++;
                
                zatopiony = SprawdzCzyZatopiony(x, y);
                
                Log($"Przeciwnik trafił w pole {(char)('A' + y)}{x + 1}!");
                
                if (mojeTrafioneStatki >= WSZYSTKIE_POLA_STATKOW)
                {
                    WyslijWiadomosc("PRZEGRANA");
                    fazaGry = FazaGry.Koniec;
                    timerGry.Stop();
                    PokazPorazke();
                }
            }
            else
            {
                mojePlansza[x, y] = 3; // Pudło
                mojePrzyciski[x, y].BackColor = Color.White;
                mojePrzyciski[x, y].Text = "•";
                Log($"Przeciwnik spudłował - pole {(char)('A' + y)}{x + 1}");
            }
            
            string wynik = trafiony ? "TRAFIONY" : "PUDLO";
            if (zatopiony) wynik += ":ZATOPIONY";
            WyslijWiadomosc($"WYNIK:{x}:{y}:{wynik}");
            
            if (!trafiony)
            {
                mojaTura = true;
                AktualizujInterfejs();
            }
        }

        private bool SprawdzCzyZatopiony(int x, int y)
        {
            List<Point> polaStatku = new List<Point>();
            
            ZnajdzWszystkiePolaStatku(x, y, polaStatku, new bool[10, 10]);
            
            foreach (var pole in polaStatku)
            {
                if (mojePlansza[pole.X, pole.Y] == 1)
                {
                    return false;
                }
            }
            
            if (polaStatku.Count > 0)
            {
                foreach (var pole in polaStatku)
                {
                    mojePrzyciski[pole.X, pole.Y].BackColor = Color.DarkRed;
                }
                return true;
            }
            
            return false;
        }

        private void ZnajdzWszystkiePolaStatku(int x, int y, List<Point> polaStatku, bool[,] odwiedzone)
        {
            if (x < 0 || x >= 10 || y < 0 || y >= 10 || odwiedzone[x, y])
                return;
                
            if (mojePlansza[x, y] != 1 && mojePlansza[x, y] != 2)
                return;
                
            odwiedzone[x, y] = true;
            polaStatku.Add(new Point(x, y));
            
            ZnajdzWszystkiePolaStatku(x - 1, y, polaStatku, odwiedzone);
            ZnajdzWszystkiePolaStatku(x + 1, y, polaStatku, odwiedzone);
            ZnajdzWszystkiePolaStatku(x, y - 1, polaStatku, odwiedzone);
            ZnajdzWszystkiePolaStatku(x, y + 1, polaStatku, odwiedzone);
        }

        private void ObsluzWynikStrzalu(int x, int y, bool trafiony, bool zatopiony)
        {
            if (trafiony)
            {
                planszaPrzeciwnika[x, y] = 2; // Trafiony
                przyciskiPrzeciwnika[x, y].BackColor = zatopiony ? Color.DarkRed : Color.Red;
                przyciskiPrzeciwnika[x, y].Text = "X";
                przyciskiPrzeciwnika[x, y].Enabled = false;
                statkiPrzeciwnikaTrafione++;
                
                Log($"Trafiłeś w pole {(char)('A' + y)}{x + 1}!");
                if (zatopiony)
                {
                    Log("Zatopiłeś statek!");
                }
                
                if (statkiPrzeciwnikaTrafione >= WSZYSTKIE_POLA_STATKOW)
                {
                    fazaGry = FazaGry.Koniec;
                    timerGry.Stop();
                    PokazZwyciestwo();
                }
                else
                {
                    mojaTura = true;
                    AktualizujInterfejs();
                }
            }
            else
            {
                planszaPrzeciwnika[x, y] = 3; // Pudło
                przyciskiPrzeciwnika[x, y].BackColor = Color.LightCyan;
                przyciskiPrzeciwnika[x, y].Text = "•";
                przyciskiPrzeciwnika[x, y].Enabled = false;
                
                Log($"Pudło - pole {(char)('A' + y)}{x + 1}");
                
                mojaTura = false;
                AktualizujInterfejs();
            }
        }

        private void PokazZwyciestwo()
        {
            MessageBox.Show("WYGRAŁES", "Zwycięstwo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblStatus.Text = "ZWYCIĘSTWO";
            lblStatus.ForeColor = Color.Green;
        }

        private void PokazPorazke()
        {
            MessageBox.Show("PRZEGRAŁEŚ", "Przegrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblStatus.Text = "PRZEGRANA";
            lblStatus.ForeColor = Color.Red;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            try
            {
                writer?.Close();
                reader?.Close();
                client?.Close();
                listener?.Stop();

                buttonDolacz.Enabled = true;
                buttonStop.Enabled = false;
                buttonWyslij.Enabled = false;
                txtAdres.Enabled = true;
                txtPort.Enabled = true;

                Log("Rozłączono");
            }
            catch (Exception ex)
            {
                Log($"Błąd przy rozłączaniu: {ex.Message}");
            }
        }

        private void buttonWyslij_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtWiadomosc.Text))
            {
                WyslijWiadomosc(txtWiadomosc.Text);
                Log($"Ja: {txtWiadomosc.Text}");
                txtWiadomosc.Clear();
            }
        }

        private void WyslijWiadomosc(string message)
        {
            try
            {
                writer?.WriteLine(message);
            }
            catch (Exception ex)
            {
                Log($"Błąd wysyłania: {ex.Message}");
            }
        }

        private void buttonOrientacja_Click(object sender, EventArgs e)
        {
            poziomo = !poziomo;
            buttonOrientacja.Text = poziomo ? "Orientacja: Poziomo" : "Orientacja: Pionowo";
        }

        private void buttonPoddaj_Click(object sender, EventArgs e)
        {
            if (fazaGry == FazaGry.Gra)
            {
                var result = MessageBox.Show("Czy chcesz się poddać?", "Poddanie", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    WyslijWiadomosc("PODDAJ");
                    fazaGry = FazaGry.Koniec;
                    timerGry.Stop();
                    PokazPorazke();
                }
            }
        }

        private void timerGry_Tick(object sender, EventArgs e)
        {
            czasGrySekundy++;
            int minuty = czasGrySekundy / 60;
            int sekundy = czasGrySekundy % 60;
            lblCzasGry.Text = $"Czas gry: {minuty:D2}:{sekundy:D2}";
        }

        private void txtAdres_TextChanged(object sender, EventArgs e) { }
        private void txtPort_TextChanged(object sender, EventArgs e) { }
        private void txtLog_TextChanged(object sender, EventArgs e) { }
        private void txtWiadomosc_TextChanged(object sender, EventArgs e) { }
        private void buttonStart_Click(object sender, EventArgs e) { }

        private void lblTura_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
