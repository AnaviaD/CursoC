using System.Diagnostics;
using System.Media;
using System.Timers;

namespace StopWatch
{
    public partial class Form1 : Form
    {

        System.Timers.Timer timer;
        int h, m, s, ms;
        public SoundPlayer s_ara1, s_ara2, s_ara3, s_senpai, s_uwu, s_oniichan;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            inicializarSonidos();
            //Desabilitamos el btn de stop
            stopBtn.Enabled = false;
        }

        private void inicializarSonidos()
        {
            //Damos configuraciones iniciales al sonido
            s_ara1 = new SoundPlayer(Properties.Resources.aara_ara1);

            s_ara2 = new SoundPlayer(Properties.Resources.ara_ara2);

            s_ara3 = new SoundPlayer(Properties.Resources.ara_ara3);

            s_senpai = new SoundPlayer(Properties.Resources.senpai);

            s_uwu = new SoundPlayer(Properties.Resources.uwu_hannah);

            s_oniichan = new SoundPlayer(Properties.Resources.oniichan);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1;
            timer.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object? sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                ms += 1;
                if (ms == 100)
                {
                    ms = 0;
                    s += 1;
                }
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }

                textScreen.Text = string.Format("{0}:{1}:{2}:{3}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'), ms.ToString().PadLeft(2, '0'));


                // Comprueba si han pasado 20 minutos desde la última vez que se llamó a la función
                if ((m % 20 == 0) && (s == 0) && (ms == 0))
                {
                    // Llama a la función que deseas ejecutar cada 20 minutos
                    sonidosRandom();
                }

            }));
        }

        private void sonidosRandom()
        {
            // Genera un número aleatorio entre 1 y 6
            int numeroAleatorio = random.Next(1, 5);

            // Utiliza un switch para seleccionar y reproducir el sonido correspondiente al número aleatorio
            switch (numeroAleatorio)
            {
                case 1:
                    s_ara1.Play();
                    break;
                case 2:
                    s_ara2.Play();
                    break;
                case 3:
                    s_ara3.Play();
                    break;
                case 4:
                    s_uwu.Play();
                    break;
                case 5:
                    s_oniichan.Play();
                    break;
                default:
                    s_oniichan.Play();
                    break;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            timer.Start();
            //Damos estado a los botones
            cb_mainAction.Enabled = false;
            startBtn.Enabled = false;
            resetBtn.Enabled = false;
            stopBtn.Enabled = true;

            s_senpai.Play();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer.Stop();
            //Damos estado a los botones
            cb_mainAction.Enabled = true;
            startBtn.Enabled = true;
            resetBtn.Enabled = true;
            stopBtn.Enabled = false;

            s_ara2.Play();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            timer.Stop();
            h = 0;
            m = 0;
            s = 0;
            ms = 0;
            textScreen.Text = "00:00:00:00";
        }

        private void lb_mainAction_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cb_mainAction_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cb_mainAction.SelectedItem.ToString().ToUpper()) 
            {
                case ".NET":
                    { pb_showImage.Image = Properties.Resources.dotNet; }
                    break;

                case "ANGULAR":
                    { pb_showImage.Image = Properties.Resources.angular; }
                    break;

                case "AZURE":
                    { pb_showImage.Image = Properties.Resources.azure; }
                    break;

                case "BLENDER":
                    { pb_showImage.Image = Properties.Resources.blender; }
                    break;

                case "HACKERRANK":
                    { pb_showImage.Image = Properties.Resources.hackerRank; }
                    break;

                case "LINKEDIN":
                    { pb_showImage.Image = Properties.Resources.linkedin; }
                    break;

                default:
                    { pb_showImage.Image = Properties.Resources._default; }
                    break;
            }

            pb_showImage.SizeMode = PictureBoxSizeMode.Zoom;

        }
    }
}
