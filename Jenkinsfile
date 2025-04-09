pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/OscarRico-9711/Selenium-pom-nunit-basic.git'
            }
        }
        
        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Run Tests') {
            steps {
                bat '''
                    REM Limpia resultados previos
                    if exist "TestResults" rmdir /Q /S "TestResults"
                    if exist "allure-results" rmdir /Q /S "allure-results"
                    
                    REM Ejecuta pruebas con logger TRX (para diagnóstico)
                    dotnet test --configuration Release --logger "trx;LogFileName=TestResults/results.trx" --results-directory TestResults
                    
                    REM Genera resultados de Allure manualmente (si el logger falla)
                    xcopy /Y /Q "TestResults\\*" "allure-results\\" || echo "No se copiaron archivos"
                '''
            }
        }
    }

    post {
        always {
            // Genera reporte Allure (si hay archivos)
            allure([
                includeProperties: false,
                jdk: '',
                properties: [],
                reportBuildPolicy: 'ALWAYS',
                results: [[path: 'allure-results']]
            ])
            
            // Archiva resultados para debug
            archiveArtifacts artifacts: '**/TestResults/**', allowEmptyArchive: true
        }
    }
}