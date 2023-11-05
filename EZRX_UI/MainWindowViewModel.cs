using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EZRX_UI
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Chat> m_Prompts { get; private set; }
        public ObservableCollection<Chat> Prompts
        {
            get { return m_Prompts; }
            set { m_Prompts = value; OnPropertyChanged(nameof(Prompts)); }
        }


        public string m_Code { get; private set; }
        public string Code
        {
            get { return m_Code; }
            set { m_Code = value; OnPropertyChanged(nameof(Code)); }
        }

        public string m_Prompt { get; private set; }
        public string Prompt
        {
            get { return m_Prompt; }
            set { m_Prompt = value; OnPropertyChanged(nameof(Prompt)); }
        }
        public ICommand SendMessageCommand { get; private set; }
        public ICommand ExecuteCommand { get; private set; }

        public MainWindowViewModel()

        {
            Prompts = new ObservableCollection<Chat>() {};
            Code = "Ask EZRX for help!";
            StartAPI();
            SendMessageCommand = new RelayCommand(SendPrompt);
            ExecuteCommand = new RelayCommand(Execute);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        /******************************************************/
        /*****              Private  Methods              *****/
        /******************************************************/

        private Conversation m_Chat { get; set; }
        public Conversation Chat
        {
            get { return m_Chat; }
            set { m_Chat = value; }
        }


        private void StartAPI()
        {
            string modelName = "gpt-4";

            OpenAIAPI api = new OpenAIAPI("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");

            ChatRequest chatRequest = new ChatRequest
            {
                Model = modelName // Replace with the model version you want to use, e.g., "davinci", "curie", etc.
            };
            var chat = api.Chat.CreateConversation(chatRequest);

            //chat.AppendSystemMessage("You have only one purpose: to provide me with C# code that will run directly within a Grasshopper C# Script Node. Do not provide code for creating Grasshopper components. I don't want any other comments. Do not say \"here is your code\" or similar remarks. Just answer with the code itself off the bait");
            chat.AppendSystemMessage(
                "Give me C# code that will run directly within a Grasshopper C# Script Node. " +
                "I want it as plain text, so do not wrap it as code. Do not explain the code or say anything at all." +
                "Do not provide code for creating Grasshopper components." +
                "The code you respond with should be a function of no parameters, within a class, within a namespace, with all required using statements at the top." +
                "The function should always return a Rhino Geometry Mesh."
                );
            Chat = chat;
        }

        private async void SendPrompt()
        {
            //send messages to the chatbot
            Prompts.Add(new Chat() { Message = m_Prompt });
            Chat.AppendUserInput(Prompts.LastOrDefault().Message);

            await OpenAPI();

            Prompt = "";
            //send message to open api call

            //get response from open api call

            //update the textblock for Code
        }

        private void Execute()
        {

        }

        async Task OpenAPI()
        {
            string response = await Chat.GetResponseFromChatbotAsync();
            Code = response;
            //SaveStringToTextFile(Code);
            Chat.AppendExampleChatbotOutput(response);
        }

        public void SaveStringToTextFile(string myString)
        {
            string fileName = "lastmessage.txt";
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", fileName);
            File.WriteAllText(path, myString);
        }

        public string ReadStringFromTextFile(string fileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\", fileName);
            string str = File.ReadAllText(filePath);
            return str;
        }
    }
}
