using ModelLibrary.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoodFilmsApp
{
    public partial class InformationDataGridWindow : Form
    {
        // Lists to store language, studio, and genre models
        private List<LanguageModel> _languages;
        private List<StudioModel> _studios;
        private List<GenreModel> _genres;

        // Constructor with parameter for languages
        public InformationDataGridWindow(List<LanguageModel> languages)
        {
            InitializeComponent();
            _languages = languages;
        }

        // Constructor with parameter for studios
        public InformationDataGridWindow(List<StudioModel> studios)
        {
            InitializeComponent();
            _studios = studios;
        }

        // Constructor with parameter for genres
        public InformationDataGridWindow(List<GenreModel> genres)
        {
            InitializeComponent();
            _genres = genres;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        // Form load
        private void InformationDataGridWİndow_Load(object sender, System.EventArgs e)
        {
            if (_studios != null)
            {
                // Bind studios data to the DataGridView
                dgwMain.DataSource = _studios;
                // Hide unnecessary columns
                dgwMain.Columns["Id"].Visible = false;
                dgwMain.Columns["Chosen"].Visible = false;
            }
            else if (_languages != null)
            {
                // Bind languages data to the DataGridView
                dgwMain.DataSource = _languages;
                // Hide unnecessary columns
                dgwMain.Columns["Id"].Visible = false;
                dgwMain.Columns["Chosen"].Visible = false;
            }
            else if (_genres != null)
            {
                // Bind genres data to the DataGridView
                dgwMain.DataSource = _genres;
                // Hide unnecessary columns
                dgwMain.Columns["Id"].Visible = false;
                dgwMain.Columns["Chosen"].Visible = false;
            }
        }
    }
}
