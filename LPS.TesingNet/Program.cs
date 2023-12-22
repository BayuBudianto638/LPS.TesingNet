// Soal 1

// return (application != null && application.protected != null) ? application.protected.shieldLastRun: null;


// Soal 2

//class Program
//{
//    // Before
//    public ApplicationInfo GetInfo()
//    {
//        var application = new ApplicationInfo
//        {
//            Path = "C:/apps/",
//            Name = "Shield.exe"
//        };
//        return application;
//    }

//    // After
//    public ApplicationInfo GetInfoFixed()
//    {
//        return new ApplicationInfo
//        {
//            Path = "C:/apps/",
//            Name = "Shield.exe"
//        };
//    }
//}

//class ApplicationInfo
//{
//    public string Path { get; set;}
//    public string Name { get; set;}
//}

//// Soal 3
//class Laptop
//{
//    private string Os { get; set; } 

//    public void SetOS(string os)
//    {
//        this.Os = os;
//    }

//    public string GetOs()
//    {
//        return this.Os;
//    }

//    //public Laptop(string os)
//    //{
//    //    Os = os;
//    //}
//}

//class Program
//{
//    static void Main()
//    {
//        //var laptop = new Laptop("macOs");
//        //Console.WriteLine(laptop.Os); // Laptop os: macOs

//        var laptop = new Laptop();
//        laptop.SetOS("Linux OS");
//        Console.WriteLine(laptop.GetOs());
//    }
//}

// Soal 4
//using System; 
//using System.Collections.Generic; 
//namespace MemoryLeakExample
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var myList = new List<Product>(); //<--- Fix here - No Products Class from the question
//            while (true)
//            {
//                // populate list with 1000 integers 
//                for (int i = 0; i < 1000; i++)
//                {
//                    myList.Add(new Product(Guid.NewGuid().ToString(), i));
//                }
//                // do something with the list object 
//                Console.WriteLine(myList.Count);
//            }
//        }
//    }
//    class Product
//    {
//        public Product(string sku, decimal price)
//        {
//            SKU = sku;
//            Price = price;
//        }
//        public string SKU { get; set; }
//        public decimal Price { get; set; }
//    }
//}

// Soal 5

//using System;
//namespace MemoryLeakExample
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var publisher = new EventPublisher();
//            while (true)
//            {
//                var subscriber = new EventSubscriber(publisher);
//                // do something with the publisher and subscriber objects 
//            }
//        }
//        class EventPublisher
//        {
//            public event EventHandler MyEvent;
//            public void RaiseEvent()
//            {
//                MyEvent?.Invoke(this, EventArgs.Empty);
//            }
//        }

//        class EventSubscriber : IDisposable
//        {
//            private readonly EventPublisher _publisher;
//            public EventSubscriber(EventPublisher publisher)
//            {
//                _publisher = publisher;
//                _publisher.MyEvent += OnMyEvent;
//            }

//            public void Dispose() // Dispose the object after used
//            {
//                _publisher.MyEvent -= OnMyEvent;
//            }

//            private void OnMyEvent(object sender, EventArgs e)
//            {
//                Console.WriteLine("MyEvent raised");
//            }
//        }
//    }
//}

// Soal 6
//using System;
//using System.Collections.Generic;
//namespace MemoryLeakExample
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var rootNode = new TreeNode();
//            while (true)
//            {
//                // create a new subtree of 10000 nodes 
//                var newNode = new TreeNode();
//                for (int i = 0; i < 10000; i++)
//                {
//                    var childNode = new TreeNode();
//                    newNode.AddChild(childNode);
//                }
//                rootNode.AddChild(newNode);

//                // remove child if exist more than 10
//                if (rootNode.Children.Count > 10) // Count the children if excess 10 then
//                {
//                    rootNode.RemoveChild(rootNode.Children[0]); // remove the children
//                }
//            }
//        }
//    }
//    class TreeNode
//    {
//        private readonly List<TreeNode> _children = new List<TreeNode>();

//        public IReadOnlyList<TreeNode> Children => _children; // Lambda expression to get the treenode of List<Children>

//        public void AddChild(TreeNode child)
//        {
//            _children.Add(child);
//        }

//        public void RemoveChild(TreeNode child)
//        {
//            _children.Remove(child);
//        }
//    }
//}

// Soal 7
//using System; 
//using System.Collections.Generic; 
//class Cache
//{
//    private static Dictionary<int, object> _cache = new Dictionary<int,
//   object>();
//    public static void Add(int key, object value)
//    {
//        //_cache.Add(key, value); // before

//        // after fix
//        if (_cache.ContainsKey(key))
//        {
//            // Update the value if the key already exists
//            _cache[key] = value;
//        }
//        else
//        {
//            // Add the key-value pair if the key doesn't exist
//            _cache.Add(key, value);
//        }
//    }
//    public static object Get(int key)
//    {
//        //return _cache[key]; // before
//        // After
//        // check the key if having value in it
//        if (_cache.ContainsKey(key))
//        {
//            return _cache[key];
//        }
//        else
//        {
//            // dont return null but return object instead
//            return new object();
//        }
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        for (int i = 0; i < 1000000; i++)
//        {
//            Cache.Add(i, new object());
//        }

//        Console.WriteLine("Cache populated");
//        Console.ReadLine();
//    }
//}
