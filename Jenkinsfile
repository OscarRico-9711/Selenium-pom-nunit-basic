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
    }
}
