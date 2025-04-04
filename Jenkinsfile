pipeline {
    agent any
    
    tools {
        // Configura Allure en "Global Tool Configuration" en Jenkins
        allure 'allure' // Nombre de tu instalaci�n Allure en Jenkins
    }
    
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
                // Ejecuta tests y guarda resultados en la ubicaci�n esperada por Allure
                bat 'dotnet test --configuration Release --logger "trx;LogFileName=TestResults/testresults.trx" --results-directory TestResults'
                
                // Si usas el adaptador Allure para .NET, deber�as tener algo como:
                // bat 'dotnet test --configuration Release --logger "allure" --results-directory allure-results'
            }
            post {
                always {
                    // Convierte resultados TRX a formato Allure si es necesario
                    bat '''
                        if not exist "allure-results" mkdir allure-results
                        echo Conversi�n de formatos si es necesaria...
                        rem Aqu� ir�a el comando para convertir TRX a Allure si lo necesitas
                    '''
                }
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
                results: [[path: 'allure-results']] // O la ruta donde est�n tus resultados
            ])
            
            // Opcional: Archiva resultados para depuraci�n
            archiveArtifacts artifacts: '**/TestResults/*.trx, **/allure-results/*', allowEmptyArchive: true
        }
    }
}