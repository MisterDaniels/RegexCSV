using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ScrapperRegexAnalyser {
    public partial class Form1 : Form {

        // Inicializa Componentes Windows Forms
        public Form1() {
            InitializeComponent();
        }

        // Disparador da ação de clique no botão "Validar"
        private void validateButton_Click(object sender, EventArgs e) {

            // Verififica se o link do textBox foi de fato digitado
            if (!linkInput.Text.Equals("")) {
                linkInput.BackColor = Color.White; // Seta cor branca para o fundo - Sinal de sucesso
                linkInput.ForeColor = Color.Black; // Seta cor preta para a fonte - Sinal de sucesso

                validateWebsite(linkInput.Text, readCsv()); // Método que valida o website
            } else {
                linkInput.BackColor = Color.Red; // Seta cor vermelha para o fundo - Sinal de fracasso
                linkInput.ForeColor = Color.White; // Seta cor branca para a fonte - Sinal de fracasso
            }

        }

        // Lê o através de um Buffer o arquivo CSV, TXT ou em formato válido do algoritmo
        private Dictionary<string, string> readCsv() {

            // Hash para os dados | key = titulo do regex / value = regex em sí
            Dictionary<string, string> regexList = new Dictionary<string, string>();

            // Chama método para abrir diálogo de seleção de arquivo
            string filePath = openFileSelect();

            // Se o arquivo foi selecionado, lê. Se não ele vai enviar Hash nula
            if (filePath != null) {
                try {
                    // Lê os arquivos, coloca no Hash, key = coluna 2 (título) | value = coluna 1 (regex) - PADRÃO DO CSV DO ONE DRIVE
                    using (var csvReader = new StreamReader(@filePath)) {
                        while (!csvReader.EndOfStream) {
                            var line = csvReader.ReadLine();
                            var values = line.Split(';');

                            regexList.Add(values[1], values[0]);
                        }
                    }
                } catch (Exception error) {
                    MessageBox.Show("Erro ao acessar o arquivo... O arquivo foi selecionado ? É no formato 'regex, título' ?");
                }

            } else {
                regexList = null;
            }

            return regexList;

        }

        // Método que abre o diálogo de selecionar arquivo
        private string openFileSelect() {

            string filePath = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                // Parâmetros e pré definições
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Arquivos TXT (*.txt)|*.txt|Arquivos CSV (*.csv)|*.csv|Todos Arquivos (*.*)|*.*"; // Deve ser .txt, .csv ou .* 
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                // Se foi selecionado, seta o caminho do arquivo na váriavel
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath = openFileDialog.FileName;
                }
            }

            // Depois retorna
            return filePath;

        }

        /* Método que carrega o site em uma string (stringona), 
         * verifica se existe da match com o Regex e vai contando, depois coloca dentro do GridView.
         * Corre entre cada um dos Regex dentro do arquivo. 
         * Recebe o link para o site e os regex já capturados pelo buffer */
        public void validateWebsite(string webLink, Dictionary<string, string> regexList) {

            // Se algum regex foi lido, então faz a operação, se não mostra o erro da falta de seleção do arquivo
            if (regexList != null) {
                try {
                    // Requisição WebClient, baixa o html em uma string
                    var webClient = new WebClient();
                    string pageContent = webClient.DownloadString(webLink);

                    // Limpa o GridView
                    resultsGridView.Rows.Clear();

                    // Cria contador
                    int matchCount;

                    // Corre entre a Hash de Regex's
                    foreach (KeyValuePair<string, string> regexItem in regexList) {
                        matchCount = 0;
                        // Método para verificar se tem alguma cadeia de caracter que dá certo com o Regex
                        Match match = Regex.Match(pageContent, regexItem.Value, RegexOptions.IgnoreCase);

                        // Enquanto achar alguma conjunto que dá certo, vai contando e vai chamando o próximo
                        while (match.Success) {
                            matchCount++;
                            match = match.NextMatch();
                        }

                        // Coloca dentro de uma linha, no GridView, Hash[key] = título | Hash[value] = regex | cont = resultado | linkBox = link
                        resultsGridView.Rows.Add(regexItem.Key, regexItem.Value, matchCount, linkInput.Text);
                    }

                } catch (Exception error) {
                    linkInput.BackColor = Color.Red; // Seta cor vermelha para o fundo - Sinal de fracasso
                    linkInput.ForeColor = Color.White; // Seta cor branca para a fonte - Sinal de fracasso

                    MessageBox.Show("Erro ao conectar... Está sem internet ? O link é válido ?");
                }
            } else {
                MessageBox.Show("Você deve selecionar um arquivo .csv ou .txt ou no formato válido 'regex;título'");
            }

        }

    }

}
