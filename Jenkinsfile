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
                bat '''
                    // Limpia resultados anteriores (opcional)
                    if exist "TestResults" rmdir /Q /S "TestResults"
                    if exist "allure-results" rmdir /Q /S "allure-results"
                    
                    // Ejecuta pruebas con ambos loggers (TRX y Allure)
                    dotnet test --configuration Release --logger "trx;LogFileName=TestResults/results.trx" --logger "allure" --results-directory TestResults
                    
                    // Prepara directorio para Allure
                    if not exist "allure-results" mkdir "allure-results"
                    
                    // Copia resultados de Allure a la ubicación esperada
                    xcopy /Y /Q "TestResults\\*" "allure-results\\"
                '''
            }
        }
    }

    post {
        always {
            // Genera y publica el reporte Allure
            allure([
                includeProperties: false,
                jdk: '',
                properties: [],
                reportBuildPolicy: 'ALWAYS',
                results: [[path: 'allure-results']]
            ])
            
            // Archiva resultados para depuración
            archiveArtifacts artifacts: '**/TestResults/**', allowEmptyArchive: true
            archiveArtifacts artifacts: '**/allure-results/**', allowEmptyArchive: true
            
            // Limpieza opcional
            bat '''
                echo "Limpiando archivos temporales..."
                del /Q "*.log" || echo "No hay logs para eliminar"
            '''
        }
    }
}