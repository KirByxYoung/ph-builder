using System.Collections.Generic;

public interface ICastleLevel
{
    public IReadOnlyCollection<LevelItemsStorage> LevelItemsStorages { get; }
    public int Number { get; }
}