pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
               git branch: 'main', url: 'https://github.com/OscarRico-9711/Selenium-pom-nunit-basic.git'
            }
        }
        
        stage('Restore dependencies') {
            steps {
                bat  'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat  'dotnet build --configuration Release'
            }
        }

        stage('Run Tests') {
            steps {
                bat  'dotnet test --configuration Release --logger trx'
            }
        }

        stage('Show Report') {
            steps {
                bat  '"allure serve "C:\Users\Usuario\source\repos\Practica selenium + nunit + pom basic\bin\Debug\net8.0\allure-results"'
            }
        }
    }
}
