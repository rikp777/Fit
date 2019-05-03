namespace Data.Contexts
{
    public static class StorageTypeSetting
    {
        public static StorageTypes Setting = StorageTypes.SQL;

        public enum StorageTypes
        {
            Memory, SQL
        }

    }
}