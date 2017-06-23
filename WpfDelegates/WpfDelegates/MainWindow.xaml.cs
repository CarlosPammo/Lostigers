using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDelegates.Model;

namespace WpfDelegates
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private List<Contact> Contacts { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			Contacts = new List<Contact>
				           {
							   new Contact
								   {
                                        Id = 1,
										Name = "Camilo",
										Lastname = "Barron",
										Address = "Aurelio Melean 778",
										Telephone = "72771901"
								   },
								   new Contact
								   {
                                        Id = 2,
										Name = "Edwin",
										Lastname = "Crespo",
										Address = "San Benito",
										Telephone = "60729598"
								   },
                                   new Contact
								   {
                                        Id = 3,
										Name = "Brayer",
										Lastname = "Villagomez",
										Address = "Quillacollo",
										Telephone = "xxxxxxxx"
								   },
				           };

			DGContacts.DataContext = Contacts;
			DGContacts.Items.Refresh();
		}

		private void BtnCerrar_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BtnNew_Click(object sender, RoutedEventArgs e)
		{
			EditarContacto editor = new EditarContacto();
			editor.OnAccept += AddNewCoctact;
			editor.Show();
		}

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Contact selected = (Contact)DGContacts.SelectedItem;
            EditarContacto editor = new EditarContacto(selected);
            editor.OnAccept += EditContact;
            editor.Show();
        }

		private void BtnSearch_Click(object sender, RoutedEventArgs e)
		{
            DGContacts.DataContext = Contacts
                // Obtiene todos los contactos cuya propiedad Name 
                // Contenga el texto del texbnox Search
                .Where(c => c.Name.Contains(TbSearch.Text));
            DGContacts.Items.Refresh();
		}

		private void AddNewCoctact(Contact contact)
		{
			Contacts.Add(contact);
			DGContacts.DataContext = Contacts;
			DGContacts.Items.Refresh();
		}

        private void EditContact(Contact contact)
        {
            DGContacts.Items.Refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Contact selected = (Contact)DGContacts.SelectedItem;
            Contacts.Remove(selected);
            DGContacts.Items.Refresh();
        }
	}
}
