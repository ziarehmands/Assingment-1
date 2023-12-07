using System;

namespace PublisherSubscriberModel
{
    
    //News Publisher Interface
    public interface INewsPublisher
    {
        void RegisterSubscriber(INewsSubscriber newsSubscriber);
        void UnregisterSubscriber(INewsSubscriber newsSubscriber);
        void NotifySubscriber(string news);
    }

    public interface INewsSubscriber
    {
        void Update(string news);
    }

    class Publisher : INewsPublisher
    {
        private List<INewsSubscriber> subscribers =  new List<INewsSubscriber>();
        List<string> stringList = new List<string>();
        public void RegisterSubscriber(INewsSubscriber newsSubscriber)
        {
            subscribers.Add(newsSubscriber);
        }

        public void UnregisterSubscriber(INewsSubscriber newsSubscriber)
        {
            subscribers.Remove(newsSubscriber);
        }

        public void NotifySubscriber(string news)
        {
            for (int i = 0; i < subscribers.Count; i++)
            {
                subscribers[i].Update(news);
            }
        }
        public void addNews(string news)
        {
            stringList.Add(news);
            Console.WriteLine("A new News Update added to the list");
            NotifySubscriber(news);
        }
    }

    class Subscriber : INewsSubscriber
    {
        private string name;

        public string Name
        {
            get { return name; }
            set {  name = value; }
        }

        public Subscriber(string name)
        {
            this.name = name;
        }
        public void Update(string news)
        {
            Console.WriteLine("Subscriber " + this.name + " Received new News Update: " + news);
        }
    }


    class Program
    {
        static int Main()
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber1 = new Subscriber("Zia");
            Subscriber subscriber2 = new Subscriber("Ali");

            publisher.addNews("Update: Weather Forecast");

            publisher.RegisterSubscriber(subscriber1);
            publisher.RegisterSubscriber(subscriber2);
            publisher.addNews("Update: Important Sport Event");

            publisher.UnregisterSubscriber(subscriber1);
            publisher.addNews("Technology News: New Gadgets Released");


            return 0;
        }
    }
    

}
