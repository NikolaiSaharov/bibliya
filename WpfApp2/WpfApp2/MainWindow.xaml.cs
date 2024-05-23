using System.Windows;
using SerializationLibrary1;
using ThemeLibrary2;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private SerializationDeserialization<Person> serializer;
        private string filePath = "person.json"; 

        public MainWindow()
        {
            InitializeComponent();
            serializer = new SerializationDeserialization<Person>(filePath);
        }
        private void LightThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(Theme.Light);
        }

        private void DarkThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(Theme.Dark);
        }

        private string FormatPerson(Person person)
        {
            return $"Имя: {person.Name}\nВозраст: {person.Age}";
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person deserializedPerson = serializer.DeserializeFromFile();
                string formattedPerson = FormatPerson(deserializedPerson);
                json.Text = formattedPerson;
                MessageBox.Show($"Данные десериализованы.", "Десериализация");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка десериализации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person
            {
                Name = txtName.Text,
                Age = int.Parse(txtAge.Text)
            };

            try
            {
                serializer.SerializeToFile(person);
                MessageBox.Show("Данные сериализованы в файл.", "Сериализация");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сериализации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}