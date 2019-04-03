namespace Data.Contexts
{
    public static class StorageTypeSetting
    {
        public static StorageTypes Setting = StorageTypes.Memory;

        public enum StorageTypes
        {
            Memory, SQL
        }

    }
}