namespace _App.Game.Gameplay.Character.Stats
{
    public class CharacterHealth : HealthBase
    {
        public bool CanBeHealed => Health < _maxHealth;
        
        public void RestoreHealth(float amount)
        {
            if (CanBeHealed)
            {
                Health += amount;
                if (Health > _maxHealth)
                {
                    Health = _maxHealth;
                }
                UpdateHealthBar(Health, _maxHealth);
            }
        }
        
        protected override void UpdateHealthBar(float currentHealth, float maxHealth)
        {
            
        }
    }
}
