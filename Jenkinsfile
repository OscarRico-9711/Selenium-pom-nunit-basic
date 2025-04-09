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
                    
                    REM Ejecuta pruebas y guarda resultados de Allure en la ruta por defecto (bin/Release/net8.0/allure-results)
                    dotnet test --configuration Release --logger "allure"
                    
                    REM Copia los resultados de Allure a la raíz (para que Jenkins los encuentre)
                    xcopy /Y /Q "bin\\Release\\net8.0\\allure-results\\*" "allure-results\\" || echo "No se copiaron archivos"
                '''
            }
        }
    }

    post {
        always {
            // Genera reporte Allure desde la carpeta raíz
            allure([
                includeProperties: false,
                jdk: '',
                properties: [],
                reportBuildPolicy: 'ALWAYS',
                results: [[path: 'allure-results']]
            ])
            
            // Archiva resultados para debug (opcional)
            archiveArtifacts artifacts: '**/allure-results/**', allowEmptyArchive: true
        }
    }
}