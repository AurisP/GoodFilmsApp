using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GoodFilmsApp
{
    public partial class DataGridWindow : Form
    {
        //// Lists to store different models
        List<StudioModel> _studioModels;
        List<GenreModel> _genreModel;
        List<DirectorModel> _directorModel;
        List<AgeRatingModel> _ageRatingModel;
        List<LanguageModel> _languageModels;
        bool _canCellChangeEventFire = false;


        public DataGridWindow()
        {
            InitializeComponent(); // Form components
        }

        // Constructors to populate the data grid with a list of ...
        #region data grid
        public DataGridWindow(List<StudioModel> studioModels)
        {
            InitializeComponent();
            _studioModels = studioModels;

            dgwMain.DataSource = _studioModels;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
        }

        public DataGridWindow(List<LanguageModel> languageModels)
        {
            InitializeComponent();
            _languageModels = languageModels;

            dgwMain.DataSource = _languageModels;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
        }

        public DataGridWindow(List<GenreModel> genreModel)
        {
            InitializeComponent();
            _genreModel = genreModel;

            dgwMain.DataSource = _genreModel;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
        }

        public DataGridWindow(List<DirectorModel> directorModel)
        {
            InitializeComponent();
            _directorModel = directorModel;


            tBoxDirectorSearch.Visible = true;
            tBoxDirectorSearch.Text = "";

            dgwMain.DataSource = _directorModel;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
        }


        public DataGridWindow(List<AgeRatingModel> ageRatingModel)
        {
            InitializeComponent();
            _ageRatingModel = ageRatingModel;

            dgwMain.DataSource = _ageRatingModel;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
        }
        #endregion
        //---

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            // Check which list is being displayed in the data grid and update the corresponding list in the QueryModel
            if (_studioModels != null)
            {
                List<StudioModel> studios = dgwMain.DataSource as List<StudioModel>;

                Helpers.QueryModel.Studios = studios.Where(x => x.Chosen == true).ToList();
            }
            else if (_genreModel != null)
            {
                List<GenreModel> genres = dgwMain.DataSource as List<GenreModel>;

                Helpers.QueryModel.Genres = genres.Where(x => x.Chosen == true).ToList();
            }
            else if (_directorModel != null)
            {
                Helpers.QueryModel.Directors = _directorModel.Where(x => x.Chosen == true).ToList();
            }
            else if (_ageRatingModel != null)
            {
                List<AgeRatingModel> directors = dgwMain.DataSource as List<AgeRatingModel>;

                Helpers.QueryModel.AgeRatings = directors.Where(x => x.Chosen == true).ToList();
            }
            else if (_languageModels != null)
            {
                List<LanguageModel> languages = dgwMain.DataSource as List<LanguageModel>;

                Helpers.QueryModel.Languages = languages.Where(x => x.Chosen == true).ToList();
            }


            this.Close(); // Close the form
        }

        private void tBoxDirectorSearch_TextChanged(object sender, System.EventArgs e)
        {
            string input = tBoxDirectorSearch.Text;

            if (string.IsNullOrEmpty(input))
            {
                dgwMain.DataSource = _directorModel;
                return;
            }

            #region dataTable
            DataTable dataTable = new DataTable();
            var rows = dgwMain.Rows;

            if (dgwMain.Rows.Count == 0)
            {
                dgwMain.DataSource = _directorModel;
            }
            foreach (DataGridViewColumn col in dgwMain.Columns)
            {
                dataTable.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgwMain.Rows)
            {
                DataRow dRow = dataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dataTable.Rows.Add(dRow);
            }

            dataTable.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", input);

            dgwMain.DataSource = dataTable;
            #endregion

            HandleValueChnge();

        }

        private void dgwMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_directorModel != null)
            {

                if (_canCellChangeEventFire == false)
                {
                    _canCellChangeEventFire = true;
                    return;
                }
                HandleValueChnge();
            }

        }

        private void HandleValueChnge()
        {
            List<DirectorModel> chosenValues = new List<DirectorModel>();

            foreach (DataGridViewRow row in dgwMain.Rows)
            {
                if (
                    row.Cells[0].Value != null
                    //&& row.Cells[1].Value != null
                    //&& row.Cells[2].Value != null
                    )
                {
                    var model = new DirectorModel()
                    {
                        Id = Convert.ToInt32(row.Cells[0].Value.ToString()),
                        Name = row.Cells[1].Value.ToString(),
                    };
                    if (row.Cells[2].Value == null)
                    {
                        model.Chosen = false;
                    }
                    else if (row.Cells[2].Value == DBNull.Value)
                    {
                        model.Chosen = false;
                    }
                    else
                    {
                        model.Chosen = Convert.ToBoolean(row.Cells[2].Value);
                    }

                    chosenValues.Add(model);

                }

            }

            var unChosenValues = chosenValues.Where(x => x.Chosen == false).ToList();
            chosenValues = chosenValues.Where(x => x.Chosen == true).ToList();


            for (int i = 0; i < chosenValues.Count; i++)
                _directorModel.Where(x => x.Id == chosenValues[i].Id).FirstOrDefault().Chosen = true;
            for (int i = 0; i < unChosenValues.Count; i++)
                _directorModel.Where(x => x.Id == unChosenValues[i].Id).FirstOrDefault().Chosen = false;
        }


        private void dgwMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_directorModel != null)
                dgwMain.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }




    }
}
