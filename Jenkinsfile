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
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Run Tests') {
            steps {
                bat 'dotnet test --configuration Release --logger trx'
            }
            post {
                always {
                    echo 'Guardando resultados de pruebas...'
                    bat 'allure generate allure-results -o allure-report --clean'
                }
            }
        }
    }

    post {
        always {
            echo 'Publicando reporte de Allure...'
            allure includeProperties: false, jdk: '', reportBuildPolicy: 'ALWAYS', results: [[path: 'allure-results']]
        }
    }
}
