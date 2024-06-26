﻿using ControllerLibrary;
using CSVExporterDNF;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodFilmsApp
{
    
    public partial class CSView : Form
    {
        private FilmModel film;
        private IExporter exporter;
        private Ref<string> path;
        // TODO: add path reference not value
        public CSView(FilmModel film, IExporter exporter, Ref<string> path)
        {
            InitializeComponent();
            this.film = film;
            this.exporter = exporter;
            this.path = path;
            if (path.Value != null) { lblPath.Text = path.Value; };
            txtDelimiter.Text = exporter.delimiter;
            txtTextQualifier.Text = exporter.textQualifier;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            bool delimiterEmpty = string.IsNullOrEmpty(txtDelimiter.Text);
            bool qualifierEmpty = string.IsNullOrEmpty(txtTextQualifier.Text);

            // Check if both textboxes are empty
            if (delimiterEmpty && qualifierEmpty)
            {
                txtDelimiter.BackColor = Color.Red;
                txtTextQualifier.BackColor = Color.Red;
                return; // Exit the method without further execution
            }

            // Check if txtDelimiter is empty
            if (delimiterEmpty)
            {
                txtDelimiter.BackColor = Color.Red;
                txtTextQualifier.BackColor = Color.White; // Reset background color
                return; // Exit the method without further execution
            }
            else
            {
                txtDelimiter.BackColor = Color.White; // Reset background color
            }

            // Check if txtTextQualifier is empty
            if (qualifierEmpty)
            {
                txtTextQualifier.BackColor = Color.Red;
                txtDelimiter.BackColor = Color.White; // Reset background color
                return; // Exit the method without further execution
            }
            else
            {
                txtTextQualifier.BackColor = Color.White; // Reset background color
            }

            // Get the delimiter and textqualifier 
            exporter.delimiter = txtDelimiter.Text;
            exporter.textQualifier = txtTextQualifier.Text;

            //TODO implement path as a reference to filmView

            //Ask for place for file
            if (checkBoxNewFile.Checked && path.Value != null) { }

            else
                path.Value = exporter.setFileToSave().ToString();
                
            Array filmArray = new string[,] { { film.Title, film.Description, film.Duration_Sec.ToString(), film.User_Rating.ToString()/*film.Comment*/ } };

            // Save Array to file
            try
            {
                var count = exporter.saveDataToCsv(ref filmArray, checkBoxAppend.Checked);
            }
            catch (Exception ex)
            {
                path.Value = "";
                lblPath.Text = path.Value;
                MessageBox.Show("Error occurred while saving CSV file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            this.Close();
        }
    }
}
