namespace Sistema_de_Gestión_Escolar___75__Parcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = textBox1.Text;
                string contraseña = textBox2.Text;
                string filePath = @"C:\Users\Ces\source\repos\Sistema de Gestión Escolar - 75% Parcial\Sistema de Gestión Escolar - 75% Parcial\bin\Debug\usuarioscole.txt";

                // Leemos el archivo de usuarios y contraseñas
                string[] lines = File.ReadAllLines(filePath);

                // Verificamos si las credenciales coinciden con alguna entrada en el archivo
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');

                    if (parts.Length == 2 && parts[0] == usuario && parts[1] == contraseña)
                    {
                        this.Hide();
                        // Las credenciales son correctas, abrir Form3
                        Form3 form3 = new Form3();
                        form3.ShowDialog(); // Mostrar Form3 como un diálogo modal.
                        this.Hide();

                        return;
                    }
                }

                MessageBox.Show("Los datos de inicio de sesión son incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.Message, "Error");
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog(); // Mostrar Form2 como un diálogo modal.
        }
    }
}