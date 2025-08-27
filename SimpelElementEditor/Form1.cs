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
using SimpelElementEditor;
using System.Text.Json;
using SimpelElementEditor.ESO.Elements;

namespace SimpelElementEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //public static ElementsTemplate CurrentElementsTemplate { get; set; }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            //try
           // {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
            {
                DataFiles.load(dialog.FileName);

                propertyGridaiPolicy.SelectedObject = DataFiles.aiPolicyTemplate;
                propertyGridaiPolicy.ExpandSingleRoot();


                propertyGridPath.SelectedObject = DataFiles.pathTemplate;
                propertyGridPath.ExpandSingleRoot();

                propertyGridExtraDrops.SelectedObject = DataFiles.extraDropsTemplate;


                propertyGridgShop.SelectedObject = DataFiles.gShopTemplate;
                propertyGridgShop.ExpandSingleRoot();
                propertyGridElements.SelectedObject = DataFiles.elementsTemplate;
                propertyGridMapData.SelectedObject = DataFiles.mapData;


                propertyGridMaster.SelectedObject = new DataFilesWrapper();
                readJSON();
            }
            //}
            //catch
///{
            //    MessageBox.Show("Error Loading files");
            //}
        }

        private void readJSON()
        {
            string jsonPath = "config.json"; 
            string jsonContent = File.ReadAllText(jsonPath);

            Config config = JsonSerializer.Deserialize<Config>(jsonContent);

            if (string.IsNullOrWhiteSpace(config.pathskillstrtxt))
            {
                Console.WriteLine("pathskillstrtxt is missing in config.json");
                return;
            }

            PropertyGridHelper.RegisterExpandableListsSafe(typeof(ESO.Skills.SkillsTemplate));
            ESO.Skills.SkillsTemplate skills = new ESO.Skills.SkillsTemplate();
            skills.skill = skills.Read(config.pathskillstrtxt);
            DataFiles.SkillsTemplate = skills;
            propertyGrid3.SelectedObject = skills;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*",
                DefaultExt = "data",
                AddExtension = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write)))
                {
                    DataFiles.elementsTemplate.Write(bw, DataFiles.elementsTemplate);
                }

                MessageBox.Show("elements saved succesful.", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timerSearch.Stop();
            timerSearch.Start();
        }

        private void timerSearch_Tick(object sender, EventArgs e)
        {
            timerSearch.Stop();

            if (DataFiles.elementsTemplate == null) return;
            if (textBox1.Text == "" && propertyGridElements.SelectedObject != DataFiles.elementsTemplate)
                propertyGridElements.SelectedObject = DataFiles.elementsTemplate;
            else if (textBox1.Text.Length >= 3)
            {
                propertyGridElements.SelectedObject = new FilteredElementsTemplate(DataFiles.elementsTemplate, textBox1.Text);
                propertyGridElements.ExpandSmallLists(5);
                propertyGridElements.ExpandSingleRoot();
            }
        }

        private void propertyGridaiPolicy_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            GridItem gi = propertyGridaiPolicy.SelectedGridItem;
            ESO.aiPolicy.CPolicyData parentPolicy = null;
            while (gi != null)
            {
                if (gi.Value is ESO.aiPolicy.CPolicyData policy)
                {
                    parentPolicy = policy;
                    break;
                }
                gi = gi.Parent;
            }
            if (parentPolicy != null && parentPolicy.id != DataFiles.selectedaiPolicy)
            {
                int parentId = parentPolicy.id;
                DataFiles.selectedaiPolicy = parentId;
                listBox1.Items.Clear();

                var matchingItems = DataFiles.elementsTemplate.MONSTER_ESSENCE
                    .Where(m => m.common_strategy == parentId);

                foreach (var item in matchingItems)
                {
                    listBox1.Items.Add($"{item.id} - {item.name}");
                }
            }
        }
    }

    public class Config
    {
        public string pathPathData { get; set; }
        public string pathTasks { get; set; }
        public string pathskillstrtxt { get; set; }
        
    }
}
