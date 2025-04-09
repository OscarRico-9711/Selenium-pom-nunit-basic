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
                // 1. Ejecutar tests normalmente (esto generará allure-results si tu proyecto tiene Allure.NUnit configurado)
                bat 'dotnet test --configuration Release'
            }
        }
    }

    post {
        always {
            // Publicar reporte desde la ruta correcta
            allure([
                includeProperties: false,
                jdk: '',
                properties: [],
                reportBuildPolicy: 'ALWAYS',
                results: [[path: 'allure-results']]
            ])
            
            archiveArtifacts artifacts: '**/allure-results/**', allowEmptyArchive: true
        }
    }
}
