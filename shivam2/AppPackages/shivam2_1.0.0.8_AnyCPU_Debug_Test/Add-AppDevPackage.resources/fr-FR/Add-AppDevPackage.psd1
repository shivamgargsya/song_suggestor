# Localized	07/27/2012 02:16 AM (GMT)	303:4.80.0411 	Add-AppDevPackage.psd1
# Culture = "en-US"
ConvertFrom-StringData @'
###PSLOC
PromptText=[O] Oui [N] Non (valeur par défaut "N")
    PromptYesCharacter = Y
    PromptNoCharacter = N
PromptYesString=Oui
PromptNoString=Non
PackageFound=Package trouvé : {0}
CertificateFound=Certificat trouvé : {0}
DependenciesFound=Package(s) de dépendance trouvé(s) :
GettingDeveloperLicense=Acquisition de la licence de développeur...
InstallingCertificate=Installation du certificat...
InstallingPackage=\nInstallation du package...
AcquireLicenseSuccessful=Une licence de développeur a été correctement acquise.
InstallCertificateSuccessful=Le certificat a été correctement installé.
Success=\nOpération réussie : votre package a été correctement installé.
WarningInstallCert=Vous êtes sur le point d'installer un certificat numérique dans le magasin de certificats Personnes autorisées de votre ordinateur. Cette opération comporte un grave risque de sécurité et elle ne doit être exécutée que si l'émetteur de ce certificat numérique est fiable.\n\nLorsque vous avez fini d'utiliser cette application, vous devez supprimer manuellement le certificat numérique associé. Des instructions se rapportant à cette procédure sont disponibles ici :\nhttp://go.microsoft.com/fwlink/?LinkId=243053
WarningPromptContinue=\nVoulez-vous vraiment continuer ?
ElevateActions=\nAvant d'installer ce package, vous devez :
ElevateActionDevLicense=\t- Acquérir une licence de développeur
ElevateActionCertificate=\t- Installer le certificat de signature
ElevateActionsContinue=Des informations d'identification d'administrateur sont nécessaires pour continuer. Acceptez l'invite du contrôle de compte d'utilisateur et entrez votre mot de passe d'administrateur si nécessaire.
ErrorForceElevate=Vous devez fournir des informations d'identification d'administrateur pour continuer. Exécutez ce script sans le paramètre -Force ou dans une fenêtre PowerShell avec des privilèges élevés.
ErrorForceDeveloperLicense=L'acquisition d'une licence de développeur requiert l'intervention de l'utilisateur. Réexécutez le script sans le paramètre -Force.
ErrorLaunchAdminFailed=Erreur : impossible de démarrer un nouveau processus en tant qu'administrateur.
ErrorNoScriptPath=Erreur : vous devez lancer ce script à partir d'un fichier.
ErrorNoPackageFound=Erreur : aucun package trouvé dans le répertoire de scripts. Vérifiez que le package que vous voulez installer se trouve dans le même répertoire que ce script.
ErrorManyPackagesFound=Erreur : plusieurs packages trouvés dans le répertoire de scripts. Vérifiez que seul le package que vous voulez installer se trouve dans le même répertoire que ce script.
ErrorPackageUnsigned=Erreur : le package n'est pas signé numériquement ou sa signature est endommagée.
ErrorNoCertificateFound=Erreur : aucun certificat trouvé dans le répertoire de scripts. Vérifiez que le certificat utilisé pour signer le package que vous installez se trouve dans le même répertoire que ce script.
ErrorManyCertificatesFound=Erreur : plusieurs certificats trouvés dans le répertoire de scripts. Vérifiez que seul le certificat utilisé pour signer le package que vous installez se trouve dans le même répertoire que ce script.
ErrorBadCertificate=Erreur : le fichier "{0}" n'est pas un certificat numérique valide. CertUtil retourné avec le code d'erreur {1}.
ErrorExpiredCertificate=Erreur : le certificat de développeur "{0}" a expiré. Cela peut être dû à un mauvais réglage de la date et de l'heure de l'horloge système. Si les paramètres système sont corrects, contactez le propriétaire du package afin qu'il recrée ce dernier avec un certificat valide.
ErrorCertificateMismatch=Erreur : le certificat ne correspond pas à celui utilisé pour signer le package.
ErrorCertIsCA=Erreur : le certificat ne peut pas être une autorité de certification.
ErrorBannedKeyUsage=Erreur : le certificat ne peut pas avoir l'utilisation de clé suivante : {0}. L'utilisation de la clé ne doit pas être spécifiée ou elle doit être égale à "DigitalSignature".
ErrorBannedEKU=Erreur : le certificat ne peut pas avoir l'utilisation améliorée de la clé suivante : {0}. Seules les utilisations améliorées de la clé (EKU) Signature du code et Signature permanente sont autorisées.
ErrorNoBasicConstraints=Erreur : le certificat ne contient pas les extensions de contraintes de base.
ErrorNoCodeSigningEku=Erreur : le certificat ne contient pas l'utilisation améliorée de la clé pour Signature du code.
ErrorInstallCertificateCancelled=Erreur : l'installation du certificat a été annulée.
ErrorCertUtilInstallFailed=Erreur : impossible d'installer le certificat. CertUtil retourné avec le code d'erreur {0}.
ErrorGetDeveloperLicenseFailed=Erreur : impossible d'acquérir une licence de développeur. Pour plus d'informations, consultez http://go.microsoft.com/fwlink/?LinkID=252740.
ErrorInstallCertificateFailed=Erreur : impossible d'installer le certificat. État : {0}. Pour plus d'informations, consultez http://go.microsoft.com/fwlink/?LinkID=252740.
ErrorAddPackageFailed=Erreur : impossible d'installer le package.
ErrorAddPackageFailedWithCert=Erreur : impossible d'installer le package. Pour garantir la sécurité, désinstallez le certificat de signature jusqu'à ce que vous soyez en mesure d'installer le package. Des instructions se rapportant à cette procédure sont disponibles ici :\nhttp://go.microsoft.com/fwlink/?LinkId=243053
'@
