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
                bat 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Run Tests') {
            steps {
                bat '''
                    REM Limpia resultados previos
                    if exist "allure-results" rmdir /Q /S "allure-results"
                    if exist "TestResults" rmdir /Q /S "TestResults"
                    
                    REM Ejecuta pruebas y guarda resultados en TRX (para Jenkins)
                    dotnet test --configuration Release --no-build --logger "trx;LogFileName=TestResults/results.trx" --results-directory TestResults
                    
                    REM Genera resultados de Allure manualmente (si el logger no funciona)
                    xcopy /Y /Q "bin\\Release\\net8.0\\TestResults\\*" "allure-results\\" || echo "No se copiaron resultados"
                '''
            }
        }
    }

    post {
        always {
            REM Genera el reporte Allure (si hay archivos)
            allure([
                includeProperties: false,
                jdk: '',
                properties: [],
                reportBuildPolicy: 'ALWAYS',
                results: [[path: 'allure-results']]
            ])
            
            REM Archiva resultados para debug
            archiveArtifacts artifacts: '**/TestResults/**', allowEmptyArchive: true
        }
    }
}