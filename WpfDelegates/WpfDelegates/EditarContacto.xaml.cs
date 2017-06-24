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
using System.Windows.Shapes;
using WpfDelegates.Model;
using System.Text.RegularExpressions;

namespace WpfDelegates
{
	/// <summary>
	/// Interaction logic for EditarContacto.xaml
	/// </summary>
	public partial class EditarContacto : Window
	{
		private Contact Contact { get; set; }
		public delegate void GetContact(Contact contact);
		public event GetContact OnAccept;

        public EditarContacto()
        {
            InitializeComponent();
            Contact = new Contact();
        }

		public EditarContacto(Contact contact) : this()
		{
			TbAddress.Text = contact.Address;
            TbName.Text = contact.Name;
            TbLastname.Text = contact.Lastname;
            TbPhone.Text = contact.Telephone;
            Contact = contact;
		}

		private void BtnCancel_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BtnAccept_Click(object sender, RoutedEventArgs e)
		{
			Contact.Address = TbAddress.Text;
			Contact.Name = TbName.Text;
			Contact.Lastname = TbLastname.Text;
			Contact.Telephone = TbPhone.Text;
			OnAccept(Contact);
			Close();
		}

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
	}
}
