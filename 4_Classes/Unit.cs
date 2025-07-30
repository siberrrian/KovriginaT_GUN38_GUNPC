namespace _4_Classes
{
    internal class Unit
    {
        private float _health;
        private float _armour;
        public string Name { get; }
        public float Health => _health;
        public int Damage { get; }

        public Unit() : this("Unknown unit")
        {

        }

        public Unit (string name)
        {
            Name = name;
            _health = 100f;
            Damage = 5;
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
