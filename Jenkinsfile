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
                bat 'dotnet test --configuration Release --logger trx --results-directory bin/Debug/net8.0/allure-results'
            }
            post {
                always {
                    echo 'Copiando archivos de resultados de Allure...'
                    bat 'mkdir allure-results'
                    bat 'copy bin\\Debug\\net8.0\\allure-results\\* allure-results\\'
                }
            }
        }

        stage('Generate Allure Report') {
            steps {
                bat 'allure generate allure-results -o allure-report --clean'
            }
        }

        stage('Publish Allure Report') {
            steps {
                allure includeProperties: false, jdk: '', reportBuildPolicy: 'ALWAYS', results: [[path: 'allure-results']]
            }
        }
    }

    post {
        always {
            echo 'Pipeline finalizado. Revisión de reportes de Allure.'
        }
    }
}
