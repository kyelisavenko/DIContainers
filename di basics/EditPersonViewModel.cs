namespace DIBasics
{
    class EditPersonViewModel
    {
        private readonly IRepository _repository;
        private readonly Person _person;
        public EditPersonViewModel(IRepository repository)
        {
            _repository = repository;
            _person = _repository.Read(-1);
        }

        public string Name => _person.Name;
    }
}