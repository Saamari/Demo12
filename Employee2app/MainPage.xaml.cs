using Employee2app.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Employee2app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        // employee image model to combobox element
        public EmployeeImageViewModel ImageViewModel { get; set; }
        // employees model
        public EmployeeViewModel ViewModel { get; set; }
        //tietomalli GridView-elementtiin (EMployee objekti)
        //costructor
        public MainPage()
        {
            // initialize view models
            this.ImageViewModel = new EmployeeImageViewModel();
            //ComboBox new model
            this.ViewModel = new EmployeeViewModel();
            this.InitializeComponent();
        }

        // New-Button control is clicked
        private void NewEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            // add a new employee
            EmployeeImage employeeImage = (EmployeeImage)ImageComboBox.SelectedValue;
            ViewModel.AddEmployee(FirstnameTextBox.Text, LastnameTextBox.Text, JobTitleTextBox.Text, employeeImage);

            // empty UI fields
            FirstnameTextBox.Text = "";
            LastnameTextBox.Text = "";
            JobTitleTextBox.Text = "";
            ImageComboBox.SelectedIndex = -1;

            // select firstname
            FirstnameTextBox.Focus(FocusState.Programmatic);
        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = (Employee)EmployeesGridView.SelectedItem;
            // delete employee from view model
            ViewModel.RemoveEmployees(employee);
        }

        private void ModifyEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            //7get selected employee from gridview
            Employee employee = (Employee)EmployeesGridView.SelectedItem;
            //modify employee properties
            employee.Firstname = FirstnameTextBox.Text;
            employee.Lastname = LastnameTextBox.Text;
            employee.JobTitle = JobTitleTextBox.Text;
            //get selected image from combobox
            EmployeeImage employeeImage = (EmployeeImage)ImageComboBox.SelectedItem;
            //modify employee image
            employee.Image = employeeImage;
        }

        private void EmployeesGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // selected employee from Gridview
            Employee employee =(Employee) e.ClickedItem;
            //update "Form" fields UI
            FirstnameTextBox.Text = employee.Firstname;
            LastnameTextBox.Text = employee.Lastname;
            JobTitleTextBox.Text = employee.JobTitle;
            ImageComboBox.SelectedValue = employee.Image;
        }
    }
}