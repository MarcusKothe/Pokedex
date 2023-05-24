using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pokedex
{
    public partial class Pokedex : Form
    {
        public Pokedex()
        {
            InitializeComponent();

        }

        // Array and array variable for the pokemon stored in memory
        const short POKEMON_MAX = 815;
        TextBox[] ivTextboxes = new TextBox[6];

        // Labels for the stat display table
        private Label hpLabel = new Label();
        private Label attackLabel = new Label();
        private Label defenseLabel = new Label();
        private Label spAtkLabel = new Label();
        private Label spDefLabel = new Label();
        private Label speedLabel = new Label();

        // Labels for basestatview table
        private Label hpLabel2 = new Label();
        private Label attackLabel1 = new Label();
        private Label defenseLabel1 = new Label();
        private Label spAtkLabel1 = new Label();
        private Label spDefLabel1 = new Label();
        private Label speedLabel1 = new Label();

        int level = 0;
        //int hpIV = 0;
        //int attackIV = 0;
        //int defenseIV = 0;
        //int spAtkIV = 0;
        //int spDefIV = 0;
        //int speedIV = 0;

        static public short TOTAL_POKEMON = 721;
        static public short SelectedPokemon = 0;
        static public Image[] typeImages = new Image[18];
        static public Pokemon[] pokemon = new Pokemon[TOTAL_POKEMON];
        private Image[] pokemonImages = new Image[TOTAL_POKEMON];
        PokemonData PokemonInfo = new PokemonData();


        private void Pokedex_Load(object sender, EventArgs e)
        {
           
            

            #region Stat Form Loading
            // Load natures in the combobox for selection
            natureComboBox.Items.Add(Pokemon.Natures.Adamant + "    [+Atk, -Sp.Atk]");
            natureComboBox.Items.Add(Pokemon.Natures.Bashful + "    [No Modification]");
            natureComboBox.Items.Add(Pokemon.Natures.Bold + "   [+Def, -Atk]");
            natureComboBox.Items.Add(Pokemon.Natures.Brave + "   [+Atk, -Speed]");
            natureComboBox.Items.Add(Pokemon.Natures.Calm + "   [+Sp.Def, -Atk]");
            natureComboBox.Items.Add(Pokemon.Natures.Careful + "  [+Sp.Def, -Sp.Atk]");
            natureComboBox.Items.Add(Pokemon.Natures.Docile + "   [No Modification]");
            natureComboBox.Items.Add(Pokemon.Natures.Gentle + "   [+Sp.Def, -Def");
            natureComboBox.Items.Add(Pokemon.Natures.Hardy + "   [No Modification]");
            natureComboBox.Items.Add(Pokemon.Natures.Hasty + "   [+Speed, -Def]");
            natureComboBox.Items.Add(Pokemon.Natures.Impish + "   [+Def, -Sp.Atk]");
            natureComboBox.Items.Add(Pokemon.Natures.Jolly + "   [+Speed, -Sp.Atk]");
            natureComboBox.Items.Add(Pokemon.Natures.Lax + "   [+Def, -Sp.Def]");
            natureComboBox.Items.Add(Pokemon.Natures.Lonely + "   [+Atk, -Def]");
            natureComboBox.Items.Add(Pokemon.Natures.Mild + "   [+Sp.Atk, -Def]");
            natureComboBox.Items.Add(Pokemon.Natures.Modest + "   [+Sp.Atk, -Atk]");
            natureComboBox.Items.Add(Pokemon.Natures.Naive + "   [+Speed, -Sp.Def]");
            natureComboBox.Items.Add(Pokemon.Natures.Naughty + "   [+Atk, -Sp.Def]");
            natureComboBox.Items.Add(Pokemon.Natures.Quiet + "   [No Modification]");
            natureComboBox.Items.Add(Pokemon.Natures.Quirky + "   [No Modificaiton]");
            natureComboBox.Items.Add(Pokemon.Natures.Rash + "   [+Sp.Atk, -Sp.Def]");
            natureComboBox.Items.Add(Pokemon.Natures.Relaxed + "   [+Def, -Speed]");
            natureComboBox.Items.Add(Pokemon.Natures.Sassy + "   [+Sp.Def, -Speed]");
            natureComboBox.Items.Add(Pokemon.Natures.Serious + "   [No Modification]");
            natureComboBox.Items.Add(Pokemon.Natures.Timid + "   [+Speed, -Atk]");

            ivTextboxes[0] = hpIvTextBox;
            ivTextboxes[1] = attkIvTextBox;
            ivTextboxes[2] = defIvTextBox;
            ivTextboxes[3] = spaIvTextBox;
            ivTextboxes[4] = spdIvTextBox;
            ivTextboxes[5] = speedIvTextBox;

            for (byte i = 0; i < ivTextboxes.Length; ++i)
            {
                //ivTextboxes[i].TextChanged += new EventHandler(IV_TextChanged);
            }

            // Add text to the stat view table
            modifiedStatTable.Controls.Add(new Label { Text = "HP" });
            modifiedStatTable.Controls.Add(hpLabel);
            modifiedStatTable.Controls.Add(new Label { Text = "Attack" });
            modifiedStatTable.Controls.Add(attackLabel);
            modifiedStatTable.Controls.Add(new Label { Text = "Defense" });
            modifiedStatTable.Controls.Add(defenseLabel);
            modifiedStatTable.Controls.Add(new Label { Text = "Sp. Attack" });
            modifiedStatTable.Controls.Add(spAtkLabel);
            modifiedStatTable.Controls.Add(new Label { Text = "Sp. Defense" });
            modifiedStatTable.Controls.Add(spDefLabel);
            modifiedStatTable.Controls.Add(new Label { Text = "Speed" });
            modifiedStatTable.Controls.Add(speedLabel);

            zeroIvButton.Enabled = false;
            thirtyOneIvButton.Enabled = false;
            natureComboBox.Enabled = false;
            hpTrackBar.Enabled = false;
            attkTrackBar.Enabled = false;
            defTrackBar.Enabled = false;
            spaTrackBar.Enabled = false;
            spDTrackBar.Enabled = false;
            speedTrackBar.Enabled = false;


            #endregion

            #region Pokemon Display Form loading
            PokemonData LoadPokemon = new PokemonData();


            var typeImageDirectory = Directory.GetFiles(@"..\..\Resources\TypeImages");
            for (byte i = 0; i < typeImages.Length; ++i)
            {
                typeImages[i] = Image.FromFile(typeImageDirectory[i]);
            }


            var spriteDirectory = Directory.GetFiles(@"..\..\Resources\PokemonSprites");
            for (short i = 0; i < pokemonImages.Length; ++i)
            {
                pokemonImages[i] = Image.FromFile(spriteDirectory[i]);
                pokemon[i] = new Pokemon(pokemonImages[i], i + 1);
            }

            LoadPokemon.AllPokemon();

            pokemonPictureBox.Image = Image.FromFile(@"..\..\Resources\PokemonSprites\001.png"); 
            idLabel.Text = " [ " + pokemon[0].PokedexNumber.ToString() + " ] ";
            nameLabel.Text = pokemon[0].Name;
            descriptionLabel.Text = pokemon[0].Description;
            typePictureBox.Image = PokemonInfo.GetPokemonType(pokemon[0].PokemonType1);
            typePictureBox2.Image = PokemonInfo.GetPokemonType(pokemon[0].PokemonType2);

            #endregion


        }
        public void NextButtonMethod()
        {
            Disable();
            pokemonPictureBox.Image = pokemonImages[++SelectedPokemon];
            idLabel.Text = " [ " + pokemon[SelectedPokemon].PokedexNumber.ToString() + " ] ";
            nameLabel.Text = pokemon[SelectedPokemon].Name;
            descriptionLabel.Text = pokemon[SelectedPokemon].Description;
            typePictureBox.Image = PokemonInfo.GetPokemonType(pokemon[SelectedPokemon].PokemonType1);
            typePictureBox2.Image = PokemonInfo.GetPokemonType(pokemon[SelectedPokemon].PokemonType2);
            levelTextBox.Text = string.Empty;
        }
        public void BackButtonMethod()
        {
            Disable();
            pokemonPictureBox.Image = pokemonImages[--SelectedPokemon];
            idLabel.Text = " [ " + pokemon[SelectedPokemon].PokedexNumber.ToString() + " ] ";
            nameLabel.Text = pokemon[SelectedPokemon].Name;
            descriptionLabel.Text = pokemon[SelectedPokemon].Description;
            typePictureBox.Image = PokemonInfo.GetPokemonType(pokemon[SelectedPokemon].PokemonType1);
            typePictureBox2.Image = PokemonInfo.GetPokemonType(pokemon[SelectedPokemon].PokemonType2);
            levelTextBox.Text = string.Empty;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            

            if (SelectedPokemon < TOTAL_POKEMON && pokemon[SelectedPokemon].PokedexNumber <= 720)
            {
                if (pokemon[SelectedPokemon].PokedexNumber == 720)
                {
                    nextButton.Enabled = false;
                }
                NextButtonMethod();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            
            if (SelectedPokemon > 0)
            {
                BackButtonMethod();

                nextButton.Enabled = true;
            }
        }
        public void StatCalculation()
        {
            int hpIV = 0;
            int attackIV = 0;
            int defenseIV = 0;
            int spAtkIV = 0;
            int spDefIV = 0;
            int speedIV = 0;

            try
            {
                hpIV = int.Parse(hpIvTextBox.Text);
                attackIV = int.Parse(attkIvTextBox.Text);
                defenseIV = int.Parse(defIvTextBox.Text);
                spAtkIV = int.Parse(spaIvTextBox.Text);
                spDefIV = int.Parse(spdIvTextBox.Text);
                speedIV = int.Parse(speedIvTextBox.Text);
            }
            catch { }

            if (!int.TryParse(levelTextBox.Text, out level) || int.Parse(levelTextBox.Text) > 100)
            {
                MessageBox.Show("Enter a whole number between 1-100 for the Pokemon's level!.");
                return;
            }

            if (natureComboBox.SelectedIndex == -1 && levelTextBox.Text == string.Empty)
            {
                MessageBox.Show("Select a nature.");
                return;
            }

            if (hpIV < 0 || hpIV > 31 || attackIV < 0 || attackIV > 31 || defenseIV < 0 || defenseIV > 31 ||
            spAtkIV < 0 || spAtkIV > 31 || spDefIV < 0 || spDefIV > 31 || speedIV < 0 || speedIV > 31)
            {
                MessageBox.Show("Enter a whole number between 0-31 for your IVs.");
                return;
            }


            //stat calculation for Health Points
            float HPStat = (pokemon[Pokedex.SelectedPokemon].BaseHP * 2.0F + hpIV + (hpTrackBar.Value / 4.0F)) * (level / 100.0F) + 10 + level;
            hpLabel.Text = Math.Floor(HPStat).ToString();

            //stat calculation for Attack
            float attackStat = (pokemon[Pokedex.SelectedPokemon].BaseAttk * 2.0F + attackIV + (attkTrackBar.Value / 4.0F)) * (level / 100.0F) + 5;
            attackStat = GetNatureModifier("Attack", attackStat);
            attackLabel.Text = Math.Floor(attackStat).ToString();
            attackLabel.ForeColor = StatColorModifier((int)attackStat, level, "Attack");

            //stat calculation for Defense
            float defenseStat = (pokemon[Pokedex.SelectedPokemon].BaseDef * 2.0F + defenseIV + (defTrackBar.Value / 4.0F)) * (level / 100.0F) + 5;
            defenseStat = GetNatureModifier("Defense", defenseStat);
            defenseLabel.Text = Math.Floor(defenseStat).ToString();
            defenseLabel.ForeColor = StatColorModifier((int)defenseStat, level, "Defense");


            //stat calculation for Special Attack
            float spAtkStat = (pokemon[Pokedex.SelectedPokemon].BaseSPA * 2.0F + spAtkIV + (spaTrackBar.Value / 4.0F)) * (level / 100.0F) + 5;
            spAtkStat = GetNatureModifier("SpecialAtk", spAtkStat);
            spAtkLabel.Text = Math.Floor(spAtkStat).ToString();
            spAtkLabel.ForeColor = StatColorModifier((int)spAtkStat, level, "SpecialAtk");

            //stat calculation for Special Defense
            float spDefStat = (pokemon[Pokedex.SelectedPokemon].BaseSpD * 2.0F + spDefIV + (spDTrackBar.Value / 4.0F)) * (level / 100.0F) + 5;
            spDefStat = GetNatureModifier("SpecialDef", spDefStat);
            spDefLabel.Text = Math.Floor(spDefStat).ToString();
            spDefLabel.ForeColor = StatColorModifier((int)spDefStat, level, "SpecialDef");

            //stat calculation for Speed
            float speedStat = (pokemon[Pokedex.SelectedPokemon].BaseSpeed * 2.0F + speedIV + (speedTrackBar.Value / 4.0F)) * (level / 100.0F) + 5;
            speedStat = GetNatureModifier("Speed", speedStat);
            speedLabel.Text = Math.Floor(speedStat).ToString();
            speedLabel.ForeColor = StatColorModifier((int)speedStat, level, "Speed");

        }
        public Color StatColorModifier(int statToChange, int pokemonLevel, string statChosen)
        {
            int statSelected = 0;
            switch (statChosen)
            {
                case "Attack":
                    {
                        statSelected = pokemon[Pokedex.SelectedPokemon].BaseAttk;
                        break;
                    }
                case "Defense":
                    {
                        statSelected = pokemon[Pokedex.SelectedPokemon].BaseDef;
                        break;
                    }
                case "SpecialAtk":
                    {
                        statSelected = pokemon[Pokedex.SelectedPokemon].BaseSPA;
                        break;
                    }
                case "SpecialDef":
                    {
                        statSelected = pokemon[Pokedex.SelectedPokemon].BaseSpD;
                        break;
                    }
                case "Speed":
                    {
                        statSelected = pokemon[Pokedex.SelectedPokemon].BaseSpeed;
                        break;
                    }
            }

            int baseLevelStat = (int)((statSelected * 2.0F * (pokemonLevel / 100.0F)) + 5.0F);
            int natureStat = (int)GetNatureModifier(statChosen, baseLevelStat);

            if (baseLevelStat < natureStat)
            {
                return Color.IndianRed;
            }
            else if (baseLevelStat > natureStat)
            {
                return Color.RoyalBlue;
            }
            else
            {
                return Color.Black;
            }
        }
        private float GetNatureModifier(string modifiedStat, float statValue)
        {
            switch ((Pokemon.Natures)natureComboBox.SelectedIndex)
            {
                case Pokemon.Natures.Adamant:
                    {
                        if (modifiedStat == "Attack")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "SpecialAtk")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Bold:
                    {
                        if (modifiedStat == "Defense")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Attack")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Brave:
                    {
                        if (modifiedStat == "Attack")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Speed")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Calm:
                    {
                        if (modifiedStat == "SpecialDef")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Attack")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }

                    }
                case Pokemon.Natures.Careful:
                    {
                        if (modifiedStat == "SpecialDef")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "SpecialAtk")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Gentle:
                    {
                        if (modifiedStat == "SpecialDef")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Defense")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Hasty:
                    {
                        if (modifiedStat == "Speed")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Defense")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Impish:
                    {
                        if (modifiedStat == "Defense")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "SpecialAtk")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Jolly:
                    {
                        if (modifiedStat == "Speed")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "SpecialAtk")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Lax:
                    {
                        if (modifiedStat == "Defense")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "SpecialDef")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Lonely:
                    {
                        if (modifiedStat == "Attack")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Defense")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Mild:
                    {
                        if (modifiedStat == "SpecialAtk")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Defense")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Modest:
                    {
                        if (modifiedStat == "SpecialAtk")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Attack")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Naive:
                    {
                        if (modifiedStat == "Speed")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "SpecialDef")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Naughty:
                    {
                        if (modifiedStat == "Attack")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "SpecialDef")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Quiet:
                    {
                        if (modifiedStat == "SpecialAtk")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Speed")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Rash:
                    {
                        if (modifiedStat == "SpecialAtk")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "SpecialDef")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Relaxed:
                    {
                        if (modifiedStat == "Defense")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Speed")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Sassy:
                    {
                        if (modifiedStat == "SpecialDef")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Speed")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                case Pokemon.Natures.Timid:
                    {
                        if (modifiedStat == "Speed")
                        {
                            return statValue * 1.1F;
                        }
                        else if (modifiedStat == "Attack")
                        {
                            return statValue * 0.9F;
                        }
                        else
                        {
                            return statValue;
                        }
                    }
                default:
                    return statValue;
            }
        }

        private void hpTrackBar_Scroll(object sender, EventArgs e)
        {
            //Trackbar EV values
            const int EvNum = 510;
            int TrackbarValue = hpTrackBar.Value + attkTrackBar.Value + defTrackBar.Value + spaTrackBar.Value + spDTrackBar.Value + speedTrackBar.Value;

            StatCalculation();

            if (TrackbarValue < EvNum)
            {
                TrackBar bar = (TrackBar)sender;
                int barValue = bar.Value;
                trackbarTooltip.SetToolTip(bar, bar.Value.ToString());
            }
            else if (TrackbarValue == EvNum)
            {
                MessageBox.Show("Ev value cannot exceed 510!");
                hpTrackBar.Value = 0;
                attkTrackBar.Value = 0;
                defTrackBar.Value = 0;
                spaTrackBar.Value = 0;
                spDTrackBar.Value = 0;
                speedTrackBar.Value = 0;

                return;
            }
        }

        private void Disable()
        {
            IVZero();

            zeroIvButton.Enabled = false;
            thirtyOneIvButton.Enabled = false;
            natureComboBox.Enabled = false;
            hpTrackBar.Enabled = false;
            attkTrackBar.Enabled = false;
            defTrackBar.Enabled = false;
            spaTrackBar.Enabled = false;
            spDTrackBar.Enabled = false;
            speedTrackBar.Enabled = false;

            hpLabel.Text = string.Empty;
            attackLabel.Text = string.Empty;
            defenseLabel.Text = string.Empty;
            spAtkLabel.Text = string.Empty;
            spDefLabel.Text = string.Empty;
            speedLabel.Text = string.Empty;

            hpTrackBar.Value = 0;
            attkTrackBar.Value = 0;
            defTrackBar.Value = 0;
            spaTrackBar.Value = 0;
            spDTrackBar.Value = 0;
            speedTrackBar.Value = 0;
        }


        private void levelTextBox_TextChanged(object sender, EventArgs e)
        {
            string levelString = levelTextBox.Text;

            if (levelTextBox.Text == string.Empty)
            {
                Disable();
            }

            if (int.TryParse(levelString, out level))
            {
                if (level >= 0 && level <= 100)
                {
                    zeroIvButton.Enabled = true;
                    thirtyOneIvButton.Enabled = true;
                    natureComboBox.Enabled = true;
                    hpTrackBar.Enabled = true;
                    attkTrackBar.Enabled = true;
                    defTrackBar.Enabled = true;
                    spaTrackBar.Enabled = true;
                    spDTrackBar.Enabled = true;
                    speedTrackBar.Enabled = true;
                   
                    StatCalculation();
                }
                else
                {

                    MessageBox.Show("Enter a whole number between 0-100 for your Level");
                }
            }
        }
        private void IV_TextChanged(object sender, EventArgs e)
        {
            StatCalculation();
        }

        private void natureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int level;

            if (!int.TryParse(levelTextBox.Text, out level))
            {

                MessageBox.Show("Enter a whole number between 1-100 for the Pokemon's level!.");
                return;
            }

            speedLabel.ForeColor = StatColorModifier(0, level, "Speed");
            spDefLabel.ForeColor = StatColorModifier(0, level, "SpecialDef");
            spAtkLabel.ForeColor = StatColorModifier(0, level, "SpecialAtk");
            defenseLabel.ForeColor = StatColorModifier(0, level, "Defense");
            attackLabel.ForeColor = StatColorModifier(0, level, "Attack");

            if (int.Parse(levelTextBox.Text) > 100)
            {
                MessageBox.Show("Enter a whole number between 0-100 for your Level");
                return;
            }
            else
            {
                StatCalculation();
            }
        }

        private void IVZero()
        {
            ivTextboxes[0].Text = 0.ToString();
            ivTextboxes[1].Text = 0.ToString();
            ivTextboxes[2].Text = 0.ToString();
            ivTextboxes[3].Text = 0.ToString();
            ivTextboxes[4].Text = 0.ToString();
            ivTextboxes[5].Text = 0.ToString();
        }
        private void zeroIvButton_Click(object sender, EventArgs e)
        {
            IVZero();
        }

        private void thirtyOneIvButton_Click(object sender, EventArgs e)
        {
            ivTextboxes[0].Text = 31.ToString();
            ivTextboxes[1].Text = 31.ToString();
            ivTextboxes[2].Text = 31.ToString();
            ivTextboxes[3].Text = 31.ToString();
            ivTextboxes[4].Text = 31.ToString();
            ivTextboxes[5].Text = 31.ToString();
        }

        private void SearchButton_Click_1(object sender, EventArgs e)
        {
            //Make it not case sensitive. 
            string textTyped = searchBox.Text;
            textTyped = textTyped.ToLower();
            string pokemonTyped = char.ToUpper(textTyped[0]) + textTyped.Substring(1);

            if (int.TryParse(pokemonTyped, out int number))
            {
                for (short i = 0; i < TOTAL_POKEMON; ++i)
                {
                    if (pokemon[i].PokedexNumber == number)
                    {
                        SelectedPokemon = i;
                        NextButtonMethod();

                        if (pokemon[SelectedPokemon].PokedexNumber == 721)
                        {
                            nextButton.Enabled = false;
                        }
                        return;
                    }
                }
            }

            for (short i = 0; i < TOTAL_POKEMON; ++i)
            {
                if (pokemon[i].Name == pokemonTyped)
                {
                    SelectedPokemon = i;
                    NextButtonMethod();

                    return;
                }
            }

            MessageBox.Show("The name you typed doesn't exist");
        }
    }
}
