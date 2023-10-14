using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Sistema_de_Gestión_Escolar___75__Parcial
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Form5
            Form5 form5 = new Form5();

            // Configurar el formulario Form5 para que llene el pictureBox
            form5.TopLevel = false;
            form5.FormBorderStyle = FormBorderStyle.None; // Opcional para quitar bordes del formulario
            form5.Dock = DockStyle.Fill; // Opcional para llenar todo el pictureBox
            this.pictureBox3.Controls.Add(form5); // pictureBox3 es el nombre del PictureBox en Form3
            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Form6
            Form6 form6 = new Form6();

            // Configurar el formulario Form6 para que llene el pictureBox
            form6.TopLevel = false;
            form6.FormBorderStyle = FormBorderStyle.None; // Opcional para quitar bordes del formulario
            form6.Dock = DockStyle.Fill; // Opcional para llenar todo el pictureBox
            this.pictureBox3.Controls.Add(form6); // pictureBox3 es el nombre del PictureBox en Form3
            form6.Show();

            // Remover el control anterior (Form5 u otro formulario si existe)
            if (pictureBox3.Controls.Count > 1)
            {
                pictureBox3.Controls.RemoveAt(0);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Form7
            Form7 form7 = new Form7();

            // Configurar el formulario Form7 para que llene el pictureBox
            form7.TopLevel = false;
            form7.FormBorderStyle = FormBorderStyle.None; // Opcional para quitar bordes del formulario
            form7.Dock = DockStyle.Fill; // Opcional para llenar todo el pictureBox
            this.pictureBox3.Controls.Add(form7); // pictureBox3 es el nombre del PictureBox en Form3
            form7.Show();

            // Remover el control anterior (Form6 u otro formulario si existe)
            if (pictureBox3.Controls.Count > 1)
            {
                pictureBox3.Controls.RemoveAt(0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Form8
            Form8 form8 = new Form8();

            // Configurar el formulario Form8 para que llene el pictureBox
            form8.TopLevel = false;
            form8.FormBorderStyle = FormBorderStyle.None; // Opcional para quitar bordes del formulario
            form8.Dock = DockStyle.Fill; // Opcional para llenar todo el pictureBox
            this.pictureBox3.Controls.Add(form8); // pictureBox3 es el nombre del PictureBox en Form3
            form8.Show();

            // Remover el control anterior (Form7 u otro formulario si existe)
            if (pictureBox3.Controls.Count > 1)
            {
                pictureBox3.Controls.RemoveAt(0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("¿Deseas Salir?", "Save DataGridView", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
