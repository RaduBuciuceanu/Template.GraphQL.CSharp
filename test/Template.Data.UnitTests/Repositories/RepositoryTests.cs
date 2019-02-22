using Moq.AutoMock;
using Template.Data.UnitTests.Repositories.Setup;

namespace Template.Data.UnitTests.Repositories
{
    public abstract class RepositoryTests
    {
        private AutoMocker _mocker;

        protected AutoMocker Mocker => GetLazyMocker();

        protected virtual void SetupAutomapper(AutomapperSetup setup)
        {
        }

        protected virtual void SetupPagination(CreatePaginationSetup setup)
        {
        }

        protected virtual void SetupStorage(StorageSetup setup)
        {
        }

        private AutoMocker GetLazyMocker()
        {
            if (_mocker == null)
            {
                _mocker = new AutoMocker();
                SetupStorage(_mocker);
                SetupAutomapper(_mocker);
                SetupPagination(_mocker);
            }

            return _mocker;
        }

        private void SetupAutomapper(AutoMocker mocker)
        {
            var setup = new AutomapperSetup(mocker);
            SetupAutomapper(setup);
        }

        private void SetupPagination(AutoMocker mocker)
        {
            var setup = new CreatePaginationSetup(mocker);
            SetupPagination(setup);
        }

        private void SetupStorage(AutoMocker mocker)
        {
            var setup = new StorageSetup(mocker);
            SetupStorage(setup);
        }
    }
}
