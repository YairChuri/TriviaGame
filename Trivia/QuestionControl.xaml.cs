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
using System.Windows.Media.Animation;

namespace Trivia
{
    /// <summary>
    /// Interaction logic for QuestionControl.xaml
    /// </summary>
    public partial class QuestionControl : UserControl
    {
        enum STATE
        {
            COVERED,
            UNCOVERED,
            SCORED
        }
        ImageBrush _backgroundBrush;
        STATE _status;
        QuestionCenter _center;
        int _id;
        public event MessageEventHandler NewQuestionRequested;

        public QuestionControl(int id)
        {
            InitializeComponent();
            _center = new QuestionCenter(id);
            _center.LoadConfiguration();
            _id = id;

            _backgroundBrush = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), string.Format(@"Resources/{0}", _center.GetImageName()))));
            _questionCoveredGrid.Background = _backgroundBrush;
            _status = STATE.COVERED;
        }
        public void QuestionAnsweredAndDone()
        {
            FadeOutTextBlockTransition();
        }
        public void ProceeedWithPresentingQuestion()
        {
            FadeOutTransition(0.5);
        }
        public bool IsAnswered()
        {
            if (_status == STATE.SCORED)
                return true;
            else
                return false;
        }
        private void _questionControlGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (_status)
            {
                case STATE.COVERED:
                    if (null != NewQuestionRequested)
                        NewQuestionRequested(this, new MessageEventArgs(_id));
                    break;
                case STATE.UNCOVERED:
                    FadeOutTransition(0.5);
                    break;
                case STATE.SCORED:
                    break;
                default:
                    break;
            }
        }
        void fadeStoryboard_Completed(object sender, EventArgs e)
        {
            switch (_status)
            {
                case STATE.COVERED:
                    DisplayQuestion();
                    FadeInTransition(0.5);
                    break;
                case STATE.UNCOVERED:
                    DisplayAnswer();
                    _status = STATE.SCORED;
                    FadeInTransition(0.5);
                    break;
                case STATE.SCORED:
                    break;
                default:
                    break;
            }

        }

        private void DisplayAnswer()
        {
            _questionTextBlock.Text = _center.GetQuestion().Question;
            _answerATextBlock.Text = _center.GetQuestion().Answer == "A" ? "A. " + _center.GetQuestion().A : "";
            _answerBTextBlock.Text = _center.GetQuestion().Answer == "B" ? "B. " + _center.GetQuestion().B : "";
            _answerCTextBlock.Text = _center.GetQuestion().Answer == "C" ? "C. " + _center.GetQuestion().C : "";
            _answerDTextBlock.Text = _center.GetQuestion().Answer == "D" ? "D. " + _center.GetQuestion().D : "";
        }

        private void DisplayQuestion()
        {
            _questionCoveredGrid.Visibility = System.Windows.Visibility.Hidden;
            _questionUncoveredGrid.Visibility = System.Windows.Visibility.Visible;

            if (_center.IsGoldenQuestion() == QUESTION_TYPE.Gold)
                _questionUncoveredGrid.Background = Brushes.Gold;

            if (_center.IsGoldenQuestion() == QUESTION_TYPE.Poop)
            {
                _questionUncoveredGrid.Background = Brushes.SaddleBrown;
                //ImageBrush backgroundBrush = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), string.Format(@"Resources/{0}", _center.GetPoopImage()))));
                //_questionUncoveredGrid.Background = backgroundBrush;
                _answerBTextBlock.TextAlignment = TextAlignment.Center;
                _answerBTextBlock.Text = "POOP...";
                _status = STATE.SCORED;
            }
            else
            {
                _questionTextBlock.Text = _center.GetQuestion().Question;
                _answerATextBlock.Text = "A. " + _center.GetQuestion().A;
                _answerBTextBlock.Text = "B. " + _center.GetQuestion().B;
                _answerCTextBlock.Text = "C. " + _center.GetQuestion().C;
                _answerDTextBlock.Text = "D. " + _center.GetQuestion().D;
                _status = STATE.UNCOVERED;
            }
        }
        private void FadeOutTransition(double duration)
        {
            Storyboard fadeStoryboard = new Storyboard();
            fadeStoryboard.Completed += new EventHandler(fadeStoryboard_Completed);
            DoubleAnimation fadeOutAnimation = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromSeconds(duration)));
            Storyboard.SetTarget(fadeOutAnimation, this);
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath(UIElement.OpacityProperty));
            fadeStoryboard.Children.Add(fadeOutAnimation);
            fadeStoryboard.Begin();
        }
        private void FadeOutTextBlockTransition()
        {
            Storyboard fadeStoryboard = new Storyboard();
            DoubleAnimation fadeOutAnimation = new DoubleAnimation(1.0, 0.25, new Duration(TimeSpan.FromSeconds(1)));
            Storyboard.SetTarget(fadeOutAnimation, this);
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath(TextBlock.OpacityProperty));
            fadeStoryboard.Children.Add(fadeOutAnimation);
            fadeStoryboard.Begin();
        }

        private void FadeInTransition(double duration)
        {
            Storyboard fadeStoryboard = new Storyboard();
            DoubleAnimation fadeAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(duration)));
            Storyboard.SetTarget(fadeAnimation, this);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath(UIElement.OpacityProperty));
            fadeStoryboard.Children.Add(fadeAnimation);
            fadeStoryboard.Begin();
        }


    }
}
