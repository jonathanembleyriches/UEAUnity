public class Harvestable
{
    public int m_EffectID;
    public int m_amount;

    public bool m_isHarvestable;

    public Harvestable(int effectID, int amount)
    {
        m_EffectID = effectID;
        m_amount = amount;
        m_isHarvestable = false;
    }

    public int Harvest()
    {
        if (!m_isHarvestable) return 0;
        m_isHarvestable = false;

        return m_amount;
    }

    public void Respawn()
    { m_isHarvestable = true; }
}