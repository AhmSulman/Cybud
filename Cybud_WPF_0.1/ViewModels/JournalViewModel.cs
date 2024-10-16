using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cybud_WPF_0._1.Models;
using Newtonsoft.Json;
using System.Windows;
using System.IO;

namespace Cybud_WPF_0._1.ViewModels
{
    
    public class JournalViewModel
    {
        private const string JournalFilePath = "journalEntries.json";
        public string ContentFile = DateTime.Now.ToString("dd-mm-yyyy-T").Trim('-', ' ',':').ToString();

        // Collection to hold the list of journal entries
        public ObservableCollection<JournalEntry> JournalEntries { get; set; }

        // Properties for a new journal entry
        public string NewEntryTitle { get; set; }
        public string NewEntryContent { get; set; }

        // Commands for saving a new entry and loading existing ones
        public IRelayCommand SaveJournalCommand { get; }
        public IRelayCommand LoadJournalsCommand { get; }

        // Constructor
        public JournalViewModel()
        {
            JournalEntries = new ObservableCollection<JournalEntry>();
            SaveJournalCommand = new RelayCommand(SaveJournalEntry);
            LoadJournalsCommand = new RelayCommand(LoadJournalEntries);

            // Automatically load journal entries when the ViewModel is initialized
            LoadJournalEntries();
        }

        // Method to save a new journal entry
        private void SaveJournalEntry()
        {
            if (string.IsNullOrEmpty(NewEntryTitle) || string.IsNullOrEmpty(NewEntryContent))
            {
                MessageBox.Show("Please provide both a title and content.");
                return;
            }

            // Create a new journal entry
            var newEntry = new JournalEntry
            {
                Title = NewEntryTitle,
                Content = NewEntryContent
            };

            if (File.Exists(ContentFile))
            {
                File.AppendAllText(ContentFile, NewEntryContent);
            }
            else
            {
                File.WriteAllText(ContentFile, newEntry.Content);
            }
            // Add the new entry to the collection
            JournalEntries.Add(newEntry);

            // Save the journal entries to a JSON file
            SaveJournalEntriesToFile();

            // Clear the input fields
            NewEntryTitle = string.Empty;
            NewEntryContent = string.Empty;

            MessageBox.Show("Journal entry saved.");
        }

        // Method to load journal entries from the JSON file
        private void LoadJournalEntries()
        {
            if (File.Exists(JournalFilePath))
            {
                var jsonData = File.ReadAllText(JournalFilePath);
                var entries = JsonConvert.DeserializeObject<ObservableCollection<JournalEntry>>(jsonData);
                if (entries != null)
                {
                    JournalEntries.Clear();
                    foreach (var entry in entries)
                    {
                        JournalEntries.Add(entry);
                    }
                }
            }
        }


        // Helper method to save journal entries to a file
        private void SaveJournalEntriesToFile()
        {
            var jsonData = JsonConvert.SerializeObject(JournalEntries, Formatting.Indented);
            File.WriteAllText(JournalFilePath, jsonData);
        }
    }
}
