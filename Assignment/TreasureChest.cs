namespace Assignment
{

    public class TreasureChest
    {
        private State _state = State.Locked;
        private readonly Material _material;
        private readonly LockType _lockType;
        private readonly LootQuality _lootQuality;

        // Default Constructor
        public TreasureChest()
        {
            _material = Material.Iron;
            _lockType = LockType.Expert;
            _lootQuality = LootQuality.Green;
        }

private int CheckCurrentState(State beforeChangedState)
        {
            if (_state != beforeChangedState)
            {
                throw new TressureMistake($"State is not correct. Current state is {_state}.");
            }
            else{
                return 1;
            }
        }


        // Document these methods with XML documentation
        public TreasureChest(State state) : this()
        {
            _state = state;
        }

        public TreasureChest(Material material, LockType lockType, LootQuality lootQuality)
        {
            _material = material;
            _lockType = lockType;
            _lootQuality = lootQuality;
        }

        // This is called a getter
        public State GetState()
        {
            return _state;
        }

        public State? Manipulate(Action action)
        {
            if (action == Action.Open) {
                CheckCurrentState(State.Closed);
                Open();
            }
            else if (action == Action.Close){
                CheckCurrentState(State.Open);
                Close();
            }
            else if (action == Action.Lock){
                CheckCurrentState(State.Closed);
                Lock();
            }
            else if (action == Action.Unlock){
                CheckCurrentState(State.Locked);
                Unlock();
            }
            else{
                throw new TressureMistake($"The action {action} is invalid ");
            }
            return _state;
        }

        public void Unlock()
        {
            _state = State.Closed;
        }

        public void Lock()
        {
            _state = State.Locked;
        }

        public void Open()
        {
            // We should check if the chest is closed
            if (_state == State.Closed)
            {
                _state = State.Open;
            }
            else if (_state == State.Open)
            {
                Console.WriteLine("The chest is already open!");
            }
            else if (_state == State.Locked)
            {
                Console.WriteLine("The chest cannot be opened because it is locked.");
            }
        }

        public void Close()
        {
            _state = State.Closed;
        }

        public override string ToString()
        {
            return $"A {_state} chest with the following properties:\nMaterial: {_material}\nLock Type: {_lockType}\nLoot Quality: {_lootQuality}";
        }

        private static void ConsoleHelper(string prop1, string prop2, string prop3)
        {
            Console.WriteLine($"Choose from the following properties.\n1.{prop1}\n2.{prop2}\n3.{prop3}");
        }

        public enum State { Open, Closed, Locked };
        public enum Action { Open, Close, Lock, Unlock };
        public enum Material { Oak, RichMahogany, Iron };
        public enum LockType { Novice, Intermediate, Expert };
        public enum LootQuality { Grey, Green, Purple };
    }
}


public class TressureMistake : Exception
    {
        // default constructor of Tressure Miskate class
        public TressureMistake(string message) : base(message)
        {
            Console.WriteLine("---------- The Following Error Occured -----------\n");
            Console.WriteLine(message);
            Console.WriteLine("\n");
            Console.WriteLine("---------------------\n");
        }
    };