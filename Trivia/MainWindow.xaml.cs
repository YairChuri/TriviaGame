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

namespace Trivia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int _currentQuestion = -1;
        const int NUMBER_OF_ROWS = 5;
        const int NUMBER_OF_COLS = 6;
        const int NUMBER_OF_QUESTIONS = NUMBER_OF_ROWS * NUMBER_OF_COLS;
        QuestionControl[] _questionsArray;
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _questionsArray = new QuestionControl[NUMBER_OF_QUESTIONS];
            for (int col = 0; col < NUMBER_OF_COLS; col++)
            {
                for (int row = 0; row < NUMBER_OF_ROWS; row++)
                {
                    int id = row * NUMBER_OF_COLS + col;
                    _questionsArray[id] = new QuestionControl(id);
                    _questionsArray[id].NewQuestionRequested += new MessageEventHandler(newPage_QuestionSelected);
                    _questionsArray[id].SetValue(Grid.RowProperty, row);
                    _questionsArray[id].SetValue(Grid.ColumnProperty, col);
                    _mainPage.Children.Add(_questionsArray[id]);

                }
            }
        }

        void newPage_QuestionSelected(object sender, MessageEventArgs e)
        {
            if (_currentQuestion != -1)
            {
                // check if the previous question was answered
                if (_questionsArray[_currentQuestion].IsAnswered())
                {
                    _questionsArray[_currentQuestion].QuestionAnsweredAndDone();
                    _currentQuestion = e.Id;
                    _questionsArray[_currentQuestion].ProceeedWithPresentingQuestion();
                }
            }
            else
            {
                _currentQuestion = e.Id;
                _questionsArray[_currentQuestion].ProceeedWithPresentingQuestion();
            }
        }
    }
}
