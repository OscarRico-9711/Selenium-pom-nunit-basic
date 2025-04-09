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
                    if exist "allure-results" rmdir /Q /S "allure-results"
                    
                    REM Ejecuta pruebas y guarda resultados en la misma ruta que en local
                    dotnet test --configuration Release --logger "allure" --results-directory "bin/Release/net8.0/allure-results"
                    
                    REM Copia los resultados a la raíz (para que el plugin de Allure en Jenkins los encuentre)
                    xcopy /Y /Q "bin\\Release\\net8.0\\allure-results\\*" "allure-results\\" || echo "No se copiaron archivos"
                '''
            }
        }
    }

    post {
        always {
            // Genera el reporte Allure desde la carpeta raíz
            allure([
                includeProperties: false,
                jdk: '',
                properties: [],
                reportBuildPolicy: 'ALWAYS',
                results: [[path: 'allure-results']]
            ])
            
            // Opcional: Archiva los resultados para debug
            archiveArtifacts artifacts: '**/allure-results/**', allowEmptyArchive: true
        }
    }
}