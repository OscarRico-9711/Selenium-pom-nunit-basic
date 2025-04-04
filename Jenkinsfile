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
                // 1. Ejecutar tests generando resultados Allure
                bat 'dotnet test --configuration Release --logger "trx;LogFileName=TestResults/testresults.trx" --results-directory TestResults'
                
                // 2. Convertir resultados TRX a Allure (necesitas Allure.NUnit)
                bat '''
                    if not exist "allure-results" mkdir allure-results
                    dotnet test --configuration Release --logger "allure" --results-directory allure-results
                '''
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
                results: [[path: 'allure-results']] // O la ruta específica de tu proyecto
            ])
            
            // Opcional: Archivar resultados para depuración
            archiveArtifacts artifacts: '**/allure-results/**', allowEmptyArchive: true
        }
    }
}