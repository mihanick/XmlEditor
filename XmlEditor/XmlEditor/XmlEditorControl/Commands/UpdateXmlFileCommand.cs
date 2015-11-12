namespace XmlEditor.XmlEditorControl.Commands
{
    using System;
    using System.Windows.Input;
    using XmlEditor.XmlEditorControl.ViewModels;

    internal class UpdateXmlFileCommand : ICommand
    {
        private XmlFileViewModel viewModel;

        public UpdateXmlFileCommand(XmlFileViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return viewModel.CanUpdate;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add 
            {
                CommandManager.RequerySuggested += value;
            }
            remove 
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        void ICommand.Execute(object parameter)
        {
            viewModel.SaveChanges();
        }
    }
}
