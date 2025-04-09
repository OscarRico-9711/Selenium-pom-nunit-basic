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
                    // Limpia resultados previos
                    if exist "allure-results" rmdir /Q /S "allure-results"
                    
                    // Ejecuta pruebas y guarda resultados en la ruta de Release (como en local)
                    dotnet test --configuration Release --logger "allure" --results-directory "bin/Release/net8.0/allure-results"
                    
                    // Copia los resultados a la raíz (para que Allure en Jenkins los encuentre)
                    xcopy /Y /Q "bin\\Release\\net8.0\\allure-results\\*" "allure-results\\"
                '''
            }
        }
    }

    post {
        always {
            // Genera el reporte Allure desde la raíz
            allure([
                includeProperties: false,
                jdk: '',
                properties: [],
                reportBuildPolicy: 'ALWAYS',
                results: [[path: 'allure-results']]
            ])
            
            // Opcional: Archiva resultados para debug
            archiveArtifacts artifacts: '**/allure-results/**', allowEmptyArchive: true
        }
    }
}