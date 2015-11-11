namespace myDietManager.ViewModel.Converters
{
    public static class ConverterHolder
    {
        public static readonly ActivityLevelDescriptionConverter ActivityDescriptionConverter =
            new ActivityLevelDescriptionConverter();

        public static readonly BooleanOrConverter BooleanOrConverter = new BooleanOrConverter();
    }
}
