using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokeAPI;
using Newtonsoft.Json;



namespace PokemonAPI___Lazo
{
    public partial class PokeDexForm : Form
    {
        public PokeDexForm()
        {
            InitializeComponent();
        }

        public async void GetSpecies(int PokemonFindID)
        {
            PokemonSpecies p = await DataFetcher.GetApiObject<PokemonSpecies>(PokemonFindID);
            txt_Species.Text = p.Name;
            txt_BaseHappiness.Text = p.BaseHappiness.ToString();
            txt_CaptureRate.Text = p.CaptureRate.ToString();
            label_FlavorText1.Text = p.FlavorTexts[0].FlavorText;
            label_FlavorText2.Text = p.FlavorTexts[2].FlavorText;
            txt_GrowthRate.Text = p.GrowthRate.Name;
            txt_Habitat.Text = p.Habitat.Name;
            txt_EggGroup.Text = p.EggGroups[0].Name;

        }

        private void btn_Species_Click(object sender, EventArgs e)
        {
            int PokemonID;
            try
            {
                PokemonID = int.Parse(txt_IdSubmitter.Text);

                if (PokemonID > 0 && PokemonID < 387)
                {
                    GetSpecies(PokemonID);
                }
                else
                {
                     MessageBox.Show("The ID entered is not valid, please try again!");
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("The ID entered is not valid, please try again!");
            }  
        }
    }
}
