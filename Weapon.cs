
class Weapon
{
    private uint _damage;
    private uint _bullets;

    public bool CanFire => _bullets > 0;

    public void Fire(Player player)
    {
        player.TakeDamage(_damage);
        _bullets--;
    }
}

class Player
{
    private uint _health;

    public bool IsAlive => _health > 0;

    public void TakeDamage(uint damage)
    {
        if (IsAlive)
            return;

        if (_health < damage)
            _health = 0;
        else
            _health -= damage;
    }
}

class Bot
{
    public Weapon Weapon { get; private set; }

    public void OnSeePlayer(Player player)
    {
        if (player.IsAlive)
            Weapon.Fire(player);
    }
}