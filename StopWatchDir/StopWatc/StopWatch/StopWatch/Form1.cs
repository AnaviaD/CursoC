using StopWatch.Clases;
using StopWatch.Helpers;
using StopWatch.Models;
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
        saveAssignment sAsig = new saveAssignment();
        DateTime horaInicial;

        public Form1()
        {
            InitializeComponent();
            inicializarSonidos();
            //Desabilitamos el btn de stop
            startBtn.Enabled = false;
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
                    guardarAvance();
                }

            }));
        }

        private void guardarAvance()
        {
            assigmentRecordClass assigmentRecord = new assigmentRecordClass();
            assigmentClass assigment = new assigmentClass();
            DateTime currentDateTime = DateTime.Now;
            DateTime hr1Future = currentDateTime.AddHours(1);

            assigment = sAsig.obtenemosAssigmentSettings(cb_mainAction.SelectedItem.ToString());

            if (assigment != null)
            {
                //Checamos si es que existe un registro con la misma hora inicial
                assigmentRecord = sAsig.obtenerRegistroPorFecha(assigment, horaInicial);

                if (assigmentRecord != null)
                {
                    //Aqui haremos el update
                    sAsig.updateAssigmentRecord(assigmentRecord, currentDateTime);
                }
                else
                {
                    // Guardamos si es que no existe registro posterior
                    sAsig.guardamosAssigmentRecord(assigment, horaInicial, currentDateTime);
                }

            }
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

            //Damos valores a el DateTime inicial
            horaInicial = DateTime.Now;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer.Stop();
            //Damos estado a los botones
            cb_mainAction.Enabled = true;
            startBtn.Enabled = true;
            resetBtn.Enabled = true;
            stopBtn.Enabled = false;

            guardarAvance();

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

            //habilitamos o desabilitamos el btn Start
            if (cb_mainAction.SelectedItem != null)
            {
                startBtn.Enabled = true;
            }
            else
            {
                startBtn.Enabled = false;
            }

            pb_showImage.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void btnTstInsert_Click(object sender, EventArgs e)
        {
            assigmentClass assigment = new assigmentClass();
            DateTime currentDateTime = DateTime.Now;
            DateTime hr1Future = currentDateTime.AddHours(1);

            assigment = sAsig.obtenemosAssigmentSettings(cb_mainAction.SelectedItem.ToString());

            if (assigment != null)
            {
                sAsig.guardamosAssigmentRecord(assigment, horaInicial, hr1Future);
            }
        }

        private void btn_obtener_Click(object sender, EventArgs e)
        {
            //sAsig.obtenerFechaHarcodeada();
            assigmentRecordClass    assigmentRecord     = new assigmentRecordClass();
            assigmentClass          assigment           = new assigmentClass();

            assigment = sAsig.obtenemosAssigmentSettings(cb_mainAction.SelectedItem.ToString());

            if (assigment != null)
            {
                //Checamos si es que existe un registro con la misma hora inicial
                assigmentRecord = sAsig.obtenerRegistroPorFecha(assigment, horaInicial);
            }
        }
    }
}
