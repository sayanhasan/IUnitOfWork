using Deneme.Entity;
using Deneme.Project.Base;
using Microsoft.EntityFrameworkCore;

namespace Deneme.Project
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
            GetSubscribers();
        }

        bool AddSubscriber()
        {
            var subscriber = new Subscriber
            {
                SubscriberId = Guid.NewGuid(),
                FullName = textBox1.Text,
                RegisterationDate = DateTime.Now.ToString(),
                IsActive = checkBox1.Checked
            };

            var address = new Address
            {
                SubscriberId = subscriber.SubscriberId,
                Detail = textBox2.Text,
                Subscriber = subscriber
            };

            Worker.Subscribers.ChangeEntityState(subscriber, EntityState.Added);
            Worker.Address.ChangeEntityState(address, EntityState.Added);

            return Worker.SaveChanges() > 0;
        }

        void GetSubscribers()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Worker.Subscribers.Select(s => new { FullName = s.FullName, Address = s.Address.Detail, IsActivated = s.IsActive }).ToList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            AddSubscriber();
            GetSubscribers();
        }
    }
}