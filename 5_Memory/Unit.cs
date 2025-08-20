namespace _5_Memory
{
    public class Unit
    {
        private float _health;
        private float _armour;
        public string Name { get; }
        public float Health => _health;
        public Interval Damage;

        public Unit() : this("Unknown unit")
        {
        }

        public Unit (string name) : this(name, 0, 5)
        {
        }

        public Unit(string name, int minDamage, int maxDamage)
        {
            Name = name;
            _health = 100f;
            Damage.Min = minDamage;
            Damage.Max = maxDamage;
            Armour = 0.6f;
        }

        public float GetRealHealth()
        {
            return Health * (1f + Armour);
        }

        public bool SetDamage(float gettingDamage)
        {
            _health = Health - gettingDamage * Armour;
            return (Health <= 0f);
        }

        public float Armour
        {
            get { return (float) Math.Round(_armour, 2); }
            set
            {
                if (value >= 0f || value <= 1f)
                {
                    _armour = value;
                }
            }

        }

    }
}
