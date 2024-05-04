using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ControllerLibrary;

namespace GoodFilmsApp
{
    public partial class DataGridWindow : Form
    {
        //// Lists to store different models
        private Action onSave;
        private List<CStudioData> studioData;
        private List<CGenreData> genreData;
        private List<CDirectorData> directorData;
        private List<CAgeRatingData> ageRatingData;
        private List<CLanguageData> languageData;

        public DataGridWindow()
        {
            InitializeComponent(); // Form components
            onSave = () => { };
        }

        // Constructors to populate the data grid with a list of ...
        #region data grid
        public DataGridWindow(CFilter filter, Action<CFilter> onChange, List<StudioModel> studioModels)
        {
            InitializeComponent();
            studioData = studioModels
                            .OrderByDescending(x => filter.listStudios.Contains(x.Id))
                            .Select(x => new CStudioData { Id = x.Id, Studio = x.Studio, Chosen = false })
                            .ToList();
            for (var i = 0; i < studioModels.Count; i++)
            {
                if (!filter.listStudios.Contains(studioData[i].Id)) break;
                studioData[i].Chosen = true;
            }
            dgwMain.DataSource = studioData;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
            this.onSave = () => {
                filter.listStudios = dgwMain.Rows.Cast<DataGridViewRow>()
                    .Where(x => (bool)x.Cells["Chosen"].Value == true)
                    .Select(x => (int)x.Cells["Id"].Value)
                    .ToList();
                onChange(filter);
            };
        }

        public DataGridWindow(CFilter filter, Action<CFilter> onChange, List<LanguageModel> languageModels)
        {
            InitializeComponent();
            languageData = languageModels
                             .OrderByDescending(x => filter.listLanguages.Contains(x.Id))
                             .Select(x => new CLanguageData { Id = x.Id, Language = x.Language, Chosen = false })
                             .ToList();
            for (var i = 0; i < languageModels.Count; i++)
            {
                if (!filter.listLanguages.Contains(languageData[i].Id)) break;
                languageData[i].Chosen = true;
            }
            dgwMain.DataSource = languageData;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
            this.onSave = () => {
                filter.listLanguages = dgwMain.Rows.Cast<DataGridViewRow>()
                    .Where(x => (bool)x.Cells["Chosen"].Value == true)
                    .Select(x => (int)x.Cells["Id"].Value)
                    .ToList();
                onChange(filter);
            };
        }

        public DataGridWindow(CFilter filter, Action<CFilter> onChange, List<GenreModel> genreModels)
        {
            InitializeComponent();
            genreData = genreModels
                              .OrderByDescending(x => filter.listGenres.Contains(x.Id))
                              .Select(x => new CGenreData { Id = x.Id, Genre = x.Genre, Chosen = false })
                              .ToList();
            for (var i = 0; i < genreModels.Count; i++)
            {
                if (!filter.listGenres.Contains(genreData[i].Id)) break;
                genreData[i].Chosen = true;
            }
            dgwMain.DataSource = genreData;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
            this.onSave = () => {
                filter.listGenres = dgwMain.Rows.Cast<DataGridViewRow>()
                    .Where(x => (bool)x.Cells["Chosen"].Value == true)
                    .Select(x => (int)x.Cells["Id"].Value)
                    .ToList();
                onChange(filter);
            };
        }

        public DataGridWindow(CFilter filter, Action<CFilter> onChange, List<DirectorModel> directorModels)
        {
            InitializeComponent();
            directorData = directorModels
                              .OrderByDescending(x => filter.listDirectors.Contains(x.Id))
                              .Select(x => new CDirectorData { Id = x.Id, Name = x.Name, Chosen = false })
                              .ToList();
            for (var i = 0; i < directorModels.Count; i++)
            {
                if (!filter.listDirectors.Contains(directorData[i].Id)) break;
                directorData[i].Chosen = true;
            }
            dgwMain.DataSource = directorData;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
            this.onSave = () => {
                filter.listDirectors = dgwMain.Rows.Cast<DataGridViewRow>()
                    .Where(x => (bool)x.Cells["Chosen"].Value == true)
                    .Select(x => (int)x.Cells["Id"].Value)
                    .ToList();
                onChange(filter);
            };
        }
        public DataGridWindow(CFilter filter, Action<CFilter> onChange, List<AgeRatingModel> ageRatingModels)
        {
            InitializeComponent();
            ageRatingData = ageRatingModels
                              .OrderByDescending(x => filter.listAgeRatings.Contains(x.Id))
                              .Select(x => new CAgeRatingData { Id = x.Id, Rating = x.Rating, Chosen = false })
                              .ToList();
            for (var i = 0; i < ageRatingModels.Count; i++)
            {
                if (!filter.listAgeRatings.Contains(ageRatingData[i].Id)) break;
                ageRatingData[i].Chosen = true;
            }
            dgwMain.DataSource = ageRatingData;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
            this.onSave = () => {
                filter.listAgeRatings = dgwMain.Rows.Cast<DataGridViewRow>()
                    .Where(x => (bool)x.Cells["Chosen"].Value == true)
                    .Select(x => (int)x.Cells["Id"].Value)
                    .ToList();
                onChange(filter);
            };
        }
        #endregion
        //---

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            this.onSave(); // Perform save action defined in constructor
            this.Close();  // Close the form
        }

        private void tBoxDirectorSearch_TextChanged(object sender, System.EventArgs e)
        {
            /*string input = tBoxDirectorSearch.Text;

            if (string.IsNullOrEmpty(input))
            {
                dgwMain.DataSource = directorModel;
                return;
            }

            #region dataTable
            DataTable dataTable = new DataTable();
            var rows = dgwMain.Rows;

            if (dgwMain.Rows.Count == 0)
            {
                dgwMain.DataSource = directorModel;
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

            HandleValueChnge();*/

        }

        private void dgwMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*if (_directorModel != null)
            {

                if (_canCellChangeEventFire == false)
                {
                    _canCellChangeEventFire = true;
                    return;
                }
                HandleValueChnge();
            }*/

        }

        private void HandleValueChnge()
        {
            /*List<DirectorModel> chosenValues = new List<DirectorModel>();

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
                    if (row.Cells[2].Value == null || row.Cells[2].Value == DBNull.Value)
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
                _directorModel.Where(x => x.Id == unChosenValues[i].Id).FirstOrDefault().Chosen = false;*/
        }


        private void dgwMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (_directorModel != null)
            //    dgwMain.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
