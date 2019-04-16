using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionMultiplicationWForm
{

    public partial class Form1 : Form
    {
        public void RandomNombre()
        {

            Random aleatoire = new Random(); //création du random
            int premier = aleatoire.Next(2, 12); //Génère un entier compris entre 0 et 9
            int deuxieme = aleatoire.Next(2, 12);
            txtPremier.Text = premier.ToString();
            txtDeuxieme.Text = deuxieme.ToString();
            txtResultat.Text = "";
            txtOperation.Text = "";
            txtResultat.BackColor = Color.White;
        }
        public Boolean Result()
        {
            try
            {
                int proposition = int.Parse(txtResultat.Text);
                txtOperation.Text = int.Parse(txtPremier.Text) + " X " + int.Parse(txtDeuxieme.Text).ToString() + " = " + (int.Parse(txtPremier.Text) * int.Parse(txtDeuxieme.Text)).ToString();
                if (proposition == (int.Parse(txtPremier.Text) * int.Parse(txtDeuxieme.Text)))
                {

                    txtResultat.BackColor = Color.Green;
                    btnSuivante.Focus();
                    return true;
                }
                txtResultat.BackColor = Color.Red;
            }
            catch (Exception) { txtOperation.Text = "Erreur de saisie"; txtResultat.Text = ""; txtResultat.Focus(); }
            return false;
        }
        int question=1; //variable pour le nombre de question
        int juste = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grbQuestion.Text = "Question n°" + question + "/20";
            txtQuestion.Text = "0";
                RandomNombre();
           

        }


        private void txtResultat_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter && txtResultat.Text != "")
            {
               
                Result(); // on test la réponse
                if (Result() == true)
                {
                    juste++;
                }
                if (question <= 20) {
                    btnSuivante.Focus();
                    
                }
                question++;
                if (question == 21)
                {
                    btnSuivante.Visible = false;
                    groupBox2.BackColor = Color.Green;
                    btnReset.Focus();
                }
                if (txtOperation.Text == "Erreur de saisie") { txtResultat.Focus(); question--; }
               
                e.SuppressKeyPress = true;
            }
        }

        private void btnSuivante_Click(object sender, EventArgs e)
        {
            if (question < 21) {
                RandomNombre();
                txtQuestion.Text = juste.ToString();
                grbQuestion.Text = "Question n°" + question + "/20";
                txtResultat.Focus();
            }
            if (question == 21)
            {
                
                grbQuestion.Text = "Question n°" + question + "/20";
                btnSuivante.Visible = false;
                btnReset.Focus();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPremier.Text = "";
            txtDeuxieme.Text = "";
            txtOperation.Text = "";
            txtResultat.Text = "";
            question = 1;
            grbQuestion.Text = "Question n°" + question + "/20"; ;
            juste = 0;
            txtQuestion.Text = juste.ToString();
            RandomNombre();
            txtResultat.Focus();
            groupBox2.BackColor = Color.Transparent;
            btnSuivante.Visible = true;
        }
    }
}
