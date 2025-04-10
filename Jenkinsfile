pipeline {
    agent any
    
    stages {
        /*---------------------------------*/
        /* 1. CHECKOUT: Obtener código fuente */
        /*---------------------------------*/
        stage('Checkout') {
            steps {
                git branch: 'main', 
                url: 'https://github.com/OscarRico-9711/Selenium-pom-nunit-basic.git'
            }
        }
        
        /*---------------------------------*/
        /* 2. BUILD: Compilar proyecto */
        /*---------------------------------*/
        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release --no-restore'
            }
        }

        /*---------------------------------*/
        /* 3. TEST: Ejecutar pruebas con reintentos */
        /*---------------------------------*/
        stage('Run Tests') {
            steps {
                script {
                    // Reintentar hasta 3 veces todo el bloque de pruebas
                    retry(3) {
                        bat '''
                            REM Limpieza de resultados anteriores
                            if exist "TestResults" rmdir /Q /S "TestResults"
                            if exist "allure-results" rmdir /Q /S "allure-results"
                            
                            REM Ejecución de pruebas
                            dotnet test --configuration Release --no-build --logger "trx;LogFileName=TestResults/results.trx"
                            
                            REM Copia de resultados para Allure
                            xcopy /Y /Q "bin\\Release\\net8.0\\allure-results\\*" "allure-results\\" || echo "No se copiaron archivos"
                        '''
                    }
                }
            }
        }
    }

    /*---------------------------------*/
    /* POST-ACCIONES: Generar reportes */
    /*---------------------------------*/
    post {
        always {
            // Reporte Allure
            allure(
                includeProperties: false,
                jdk: '',
                properties: [],
                reportBuildPolicy: 'ALWAYS',
                results: [[path: 'allure-results']]
            )
            
            // Archivar resultados (opcional)
            archiveArtifacts artifacts: '**/TestResults/**, **/allure-results/**', allowEmptyArchive: true
            
            // Limpieza opcional
            bat '''
                echo "=== Resumen del workspace ==="
                dir /s "TestResults" || echo "No hay TestResults"
                dir /s "allure-results" || echo "No hay allure-results"
            '''
        }
    }
}