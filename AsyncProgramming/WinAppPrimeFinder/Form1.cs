namespace WinAppPrimeFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var button = new Button()
            {
                Text = "Exit",
                Size = new Size(120, 80),
                Location = new Point(10, 250)
            };

            // this.Controls.Clear();

            //    Controls.Add(button);

            //    button.Click += (sender, e) =>
            //    {
            //        MessageBox.Show(
            //            "I am just called Exit.\nI don't really exit\nIf you want to exit why dont you press cross button",
            //            "You are trapped",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Question
            //            );
            //    };
            //}

            //timer.Stop();
            //timer.Start();
        }

        private void findPrimesButton_Click(object sender, EventArgs e)
        {
            int min;
            int max;
            if(!int.TryParse(minTextBox.Text, out min))
            {
                ShowError("Invalid Value for Min");
                return;
            }

            if(!int.TryParse(maxTextBox.Text,out max))
            {
                ShowError("Invalid value for Max");
                return;
            }
            int primes = 0;
            var pu = new PrimeUtils();
            running = true;
            for(int i=min;i<max && running;i++)
            {
                if(pu.IsPrime(i))
                {
                    primes++;
                    totalPrimesTextBox.Text = primes.ToString();
                    int pc = (i - min) * 100 / (max - min+1);
                    progressBar.Value = pc;
                }
            }
            if(running)
                progressBar.Value = 100;

            running = false;
        }

        private static void ShowError(string error)
        {
            MessageBox.Show(error, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        bool running;
        int primes;
        int pc;
        private void stopButton_Click(object sender, EventArgs e)
        {
            running = false;
        }

        private void findPrimesAsyncButton_Click(object sender, EventArgs e)
        {
            int min;
            int max;
            if (!int.TryParse(minTextBox.Text, out min))
            {
                ShowError("Invalid Value for Min");
                return;
            }

            if (!int.TryParse(maxTextBox.Text, out max))
            {
                ShowError("Invalid value for Max");
                return;
            }
            primes = 0;
            var pu = new PrimeUtils();
            timer.Start();
            progressBar.Value = 0;
            Task.Factory.StartNew(() =>
            {
                running = true;
                for (int i = min; i < max && running; i++)
                {
                    if (pu.IsPrime(i))
                    {
                        primes++;
                        //totalPrimesTextBox.Text = primes.ToString();
                        pc = (i - min) * 100 / (max - min + 1);
                       // progressBar.Value = pc;
                    }
                }
                if (running)
                   pc = 100;

                running = false;
            });

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //update our UI here
            totalPrimesTextBox.Text = primes.ToString();
            progressBar.Value = pc;
            if (!running)
                timer.Stop();
        }
    }
}