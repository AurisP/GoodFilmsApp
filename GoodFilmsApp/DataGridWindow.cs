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
        private IController controller;
        private CFilter filter;
        private Action onSave;
        private Action onType;

        public DataGridWindow(IController controller, CFilter filter)
        {
            InitializeComponent(); // Form components
            this.controller = controller;
            this.filter = filter;
            onSave = () => { };
            onType = () => { };
        }

        private void initGeneric<T>(Action<CFilter, int, int, Action<List<T>>, Action<String>> request, Func<T, int> getTId, Func<T, string> getTName, Ref<List<int>> list, Action<CFilter> onChange)
        {
            this.onSave = () =>
            {
                var includeList = dgwMain.Rows.Cast<DataGridViewRow>()
                    .Where(x => (bool)x.Cells["Chosen"].Value == true)
                    .Select(x => (int)x.Cells["Id"].Value)
                    .ToList();
                var excludeList = dgwMain.Rows.Cast<DataGridViewRow>()
                    .Where(x => (bool)x.Cells["Chosen"].Value == false)
                    .Select(x => (int)x.Cells["Id"].Value)
                    .ToList();
                list.Value = list.Value
                                .Union(includeList)
                                .Where(x => !excludeList.Contains(x))
                                .ToList();
                onChange(filter);
            };
            this.onType = () =>
            {
                CFilter dataFilter = new CFilter();
                dataFilter.strSearch = tBox.Text;
                dataFilter.listIncludeIds = list.Value;
                request(dataFilter, 0, 100, (data) =>
                {
                    List<CDisplayData> displayData = data
                            .OrderByDescending(x => list.Value.Contains(getTId(x)))
                            .Select(x => new CDisplayData(getTId(x), getTName(x), false))
                            .ToList();
                    for (var i = 0; i < data.Count; i++)
                    {
                        if (!list.Value.Contains(displayData[i].Id)) break;
                        displayData[i].Chosen = true;
                    }
                    Invoke(new Action(() =>
                    {
                        dgwMain.DataSource = displayData;
                        dgwMain.Columns["Id"].Visible = false;
                        dgwMain.Columns["Chosen"].HeaderText = "";
                    }));
                }, (error) =>
                {
                    MessageBox.Show(error);
                });
            };
            this.onType();
        }
        public void initForAgeRatings(Action<CFilter> onChange)
        {
            initGeneric<AgeRatingModel>(
                (a, b, c, d, e) => controller.requestAgeRatings(a, b, c, d, e),
                (a) => a.Id,
                (a) => a.Rating,
                new Ref<List<int>>(() => filter.listAgeRatings, (x) => { filter.listAgeRatings = x; }),
                onChange);
        }
        public void initForDirectors(Action<CFilter> onChange)
        {
            initGeneric<DirectorModel>(
                (a, b, c, d, e) => controller.requestDirectors(a, b, c, d, e),
                (a) => a.Id,
                (a) => a.Name,
                new Ref<List<int>>(() => filter.listDirectors, (x) => { filter.listDirectors = x; }),
                onChange);
        }
        public void initForGenres(Action<CFilter> onChange)
        {
            initGeneric<GenreModel>(
                (a, b, c, d, e) => controller.requestGenres(a, b, c, d, e),
                (a) => a.Id,
                (a) => a.Genre,
                new Ref<List<int>>(() => filter.listGenres, (x) => { filter.listGenres = x; }),
                onChange);
        }
        public void initForLanguages(Action<CFilter> onChange)
        {
            initGeneric<LanguageModel>(
                (a, b, c, d, e) => controller.requestLanguages(a, b, c, d, e),
                (a) => a.Id,
                (a) => a.Language,
                new Ref<List<int>>(() => filter.listLanguages, (x) => { filter.listLanguages = x; }),
                onChange);
        }
        public void initForStudios(Action<CFilter> onChange)
        {
            initGeneric<StudioModel>(
                (a, b, c, d, e) => controller.requestStudios(a, b, c, d, e),
                (a) => a.Id,
                (a) => a.Studio,
                new Ref<List<int>>(() => filter.listStudios, (x) => { filter.listStudios = x; }),
                onChange);
        }
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            this.onSave(); // Perform save action defined in constructor
            this.Close();  // Close the form
        }
        private void tBox_TextChanged(object sender, EventArgs e)
        {
            this.onType();
        }
    }
}
