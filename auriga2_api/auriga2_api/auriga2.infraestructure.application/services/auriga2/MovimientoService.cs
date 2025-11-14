using auriga2.domain.entities;
using auriga2.domain.repositories;
using auriga2.infraestructure.application.models.requests;
using auriga2.infraestructure.application.models.responses;

using AutoMapper;
using System;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application
{
    public partial class ApplicationService : IApplicationService
    {


        public async Task<MovimientoResponseDto> DepositarAsync(MovimientoRequestDto request)
        {
            var cuenta = await _cuentaDomainRepository.ObtenerPorNumeroCuentaAsync(request.NumeroCuenta);
            if (cuenta == null)
                throw new InvalidOperationException("Cuenta no encontrada");

            cuenta.Depositar(request.Monto);
            await _cuentaDomainRepository.ActualizarAsync(cuenta);

            var ultimaTransaccion = cuenta.Transacciones[^1];
            var response = _mapper.Map<MovimientoResponseDto>(ultimaTransaccion);
            response.NumeroCuenta = cuenta.NumeroCuenta;
            response.SaldoActual = cuenta.Saldo;

            
            var htmlBody = GenerarHtmlDeposito(
                cuenta.Cliente.Nombre,
                ultimaTransaccion.Monto,
                cuenta.Saldo,
                cuenta.NumeroCuenta,
                ultimaTransaccion.Fecha
            );

            await _envioCorreo.EnviarCorreoAsync(
                destinatario: cuenta.Cliente.Correo,
                asunto: $" Depósito exitoso - ${ultimaTransaccion.Monto:N2}",
                cuerpo: htmlBody
            );

            return response;
        }

        public async Task<MovimientoResponseDto> RetirarAsync(MovimientoRequestDto request)
        {
            var cuenta = await _cuentaDomainRepository.ObtenerPorNumeroCuentaAsync(request.NumeroCuenta);
            if (cuenta == null)
                throw new InvalidOperationException("Cuenta no encontrada");

            cuenta.Retirar(request.Monto);
            await _cuentaDomainRepository.ActualizarAsync(cuenta);

            var ultimaTransaccion = cuenta.Transacciones[^1];
            var response = _mapper.Map<MovimientoResponseDto>(ultimaTransaccion);
            response.NumeroCuenta = cuenta.NumeroCuenta;
            response.SaldoActual = cuenta.Saldo;

         
            var htmlBody = GenerarHtmlRetiro(
                cuenta.Cliente.Nombre,
                ultimaTransaccion.Monto,
                cuenta.Saldo,
                cuenta.NumeroCuenta,
                ultimaTransaccion.Fecha
            );

            await _envioCorreo.EnviarCorreoAsync(
                destinatario: cuenta.Cliente.Correo,
                asunto: $" Retiro realizado - ${ultimaTransaccion.Monto:N2}",
                cuerpo: htmlBody
            );

            return response;
        }

        private string GenerarHtmlDeposito(string nombreCliente, decimal monto, decimal saldoActual, string numeroCuenta, DateTime fecha)
        {
            return $@"
<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <style>
        * {{
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }}
        body {{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            padding: 20px;
        }}
        .email-container {{
            max-width: 600px;
            margin: 0 auto;
            background: white;
            border-radius: 16px;
            overflow: hidden;
            box-shadow: 0 20px 60px rgba(0,0,0,0.3);
        }}
        .header {{
            background: linear-gradient(135deg, #10b981 0%, #059669 100%);
            padding: 40px 30px;
            text-align: center;
            color: white;
        }}
        .header h1 {{
            font-size: 28px;
            margin-bottom: 10px;
            font-weight: 600;
        }}
        .icon-success {{
            width: 80px;
            height: 80px;
            background: rgba(255,255,255,0.2);
            border-radius: 50%;
            margin: 0 auto 20px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 40px;
            animation: scaleIn 0.5s ease-out;
        }}
        @keyframes scaleIn {{
            from {{ transform: scale(0); }}
            to {{ transform: scale(1); }}
        }}
        .content {{
            padding: 40px 30px;
        }}
        .greeting {{
            font-size: 18px;
            color: #333;
            margin-bottom: 25px;
        }}
        .transaction-card {{
            background: linear-gradient(135deg, #f0fdf4 0%, #dcfce7 100%);
            border-left: 4px solid #10b981;
            padding: 25px;
            border-radius: 12px;
            margin: 25px 0;
        }}
        .transaction-row {{
            display: flex;
            justify-content: space-between;
            padding: 12px 0;
            border-bottom: 1px solid rgba(16, 185, 129, 0.2);
        }}
        .transaction-row:last-child {{
            border-bottom: none;
        }}
        .label {{
            color: #6b7280;
            font-size: 14px;
            font-weight: 500;
        }}
        .value {{
            color: #1f2937;
            font-weight: 600;
            font-size: 16px;
        }}
        .amount {{
            color: #10b981;
            font-size: 32px;
            font-weight: 700;
            text-align: center;
            margin: 20px 0;
        }}
        .balance-section {{
            background: #f9fafb;
            padding: 20px;
            border-radius: 12px;
            text-align: center;
            margin-top: 25px;
        }}
        .balance-label {{
            color: #6b7280;
            font-size: 14px;
            margin-bottom: 8px;
        }}
        .balance-amount {{
            color: #1f2937;
            font-size: 28px;
            font-weight: 700;
        }}
        .footer {{
            background: #f9fafb;
            padding: 30px;
            text-align: center;
            color: #6b7280;
            font-size: 13px;
            line-height: 1.6;
        }}
        .footer-logo {{
            font-size: 20px;
            font-weight: 700;
            color: #667eea;
            margin-bottom: 15px;
        }}
        .security-notice {{
            background: #fef3c7;
            border-left: 4px solid #f59e0b;
            padding: 15px;
            border-radius: 8px;
            margin-top: 25px;
            font-size: 13px;
            color: #92400e;
        }}
        @media only screen and (max-width: 600px) {{
            .content {{ padding: 30px 20px; }}
            .header {{ padding: 30px 20px; }}
            .amount {{ font-size: 28px; }}
        }}
    </style>
</head>
<body>
    <div class='email-container'>
        <div class='header'>
            <div class='icon-success'>✅</div>
            <h1>Depósito Exitoso</h1>
        </div>
        
        <div class='content'>
            <div class='greeting'>
                Hola <strong>{nombreCliente}</strong>,
            </div>
            
            <p style='color: #4b5563; line-height: 1.6; margin-bottom: 20px;'>
                Tu depósito ha sido procesado exitosamente. A continuación encontrarás los detalles de la transacción:
            </p>
            
            <div class='transaction-card'>
                <div class='transaction-row'>
                    <span class='label'>Tipo de transacción</span>
                    <span class='value'>Depósito</span>
                </div>
                <div class='transaction-row'>
                    <span class='label'>Cuenta</span>
                    <span class='value'>{numeroCuenta}</span>
                </div>
                <div class='transaction-row'>
                    <span class='label'>Fecha y hora</span>
                    <span class='value'>{fecha:dd/MM/yyyy HH:mm}</span>
                </div>
                
                <div class='amount'>
                    + ${monto:N2}
                </div>
            </div>
            
            <div class='balance-section'>
                <div class='balance-label'>Saldo disponible</div>
                <div class='balance-amount'>${saldoActual:N2}</div>
            </div>
            
            <div class='security-notice'>
                <strong>🔒 Aviso de seguridad:</strong> Si no reconoces esta transacción, contacta inmediatamente a nuestro servicio de atención al cliente.
            </div>
        </div>
        
        <div class='footer'>
            <div class='footer-logo'>🏦 Mi Banco</div>
            <p>Este es un correo automático, por favor no responder.</p>
            <p style='margin-top: 10px;'>
                © 2024 Mi Banco. Todos los derechos reservados.
            </p>
        </div>
    </div>
</body>
</html>";
        }

        private string GenerarHtmlRetiro(string nombreCliente, decimal monto, decimal saldoActual, string numeroCuenta, DateTime fecha)
        {
            return $@"
<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <style>
        * {{
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }}
        body {{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            padding: 20px;
        }}
        .email-container {{
            max-width: 600px;
            margin: 0 auto;
            background: white;
            border-radius: 16px;
            overflow: hidden;
            box-shadow: 0 20px 60px rgba(0,0,0,0.3);
        }}
        .header {{
            background: linear-gradient(135deg, #3b82f6 0%, #2563eb 100%);
            padding: 40px 30px;
            text-align: center;
            color: white;
        }}
        .header h1 {{
            font-size: 28px;
            margin-bottom: 10px;
            font-weight: 600;
        }}
        .icon-transaction {{
            width: 80px;
            height: 80px;
            background: rgba(255,255,255,0.2);
            border-radius: 50%;
            margin: 0 auto 20px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 40px;
            animation: scaleIn 0.5s ease-out;
        }}
        @keyframes scaleIn {{
            from {{ transform: scale(0); }}
            to {{ transform: scale(1); }}
        }}
        .content {{
            padding: 40px 30px;
        }}
        .greeting {{
            font-size: 18px;
            color: #333;
            margin-bottom: 25px;
        }}
        .transaction-card {{
            background: linear-gradient(135deg, #eff6ff 0%, #dbeafe 100%);
            border-left: 4px solid #3b82f6;
            padding: 25px;
            border-radius: 12px;
            margin: 25px 0;
        }}
        .transaction-row {{
            display: flex;
            justify-content: space-between;
            padding: 12px 0;
            border-bottom: 1px solid rgba(59, 130, 246, 0.2);
        }}
        .transaction-row:last-child {{
            border-bottom: none;
        }}
        .label {{
            color: #6b7280;
            font-size: 14px;
            font-weight: 500;
        }}
        .value {{
            color: #1f2937;
            font-weight: 600;
            font-size: 16px;
        }}
        .amount {{
            color: #3b82f6;
            font-size: 32px;
            font-weight: 700;
            text-align: center;
            margin: 20px 0;
        }}
        .balance-section {{
            background: #f9fafb;
            padding: 20px;
            border-radius: 12px;
            text-align: center;
            margin-top: 25px;
        }}
        .balance-label {{
            color: #6b7280;
            font-size: 14px;
            margin-bottom: 8px;
        }}
        .balance-amount {{
            color: #1f2937;
            font-size: 28px;
            font-weight: 700;
        }}
        .footer {{
            background: #f9fafb;
            padding: 30px;
            text-align: center;
            color: #6b7280;
            font-size: 13px;
            line-height: 1.6;
        }}
        .footer-logo {{
            font-size: 20px;
            font-weight: 700;
            color: #667eea;
            margin-bottom: 15px;
        }}
        .security-notice {{
            background: #fef3c7;
            border-left: 4px solid #f59e0b;
            padding: 15px;
            border-radius: 8px;
            margin-top: 25px;
            font-size: 13px;
            color: #92400e;
        }}
        @media only screen and (max-width: 600px) {{
            .content {{ padding: 30px 20px; }}
            .header {{ padding: 30px 20px; }}
            .amount {{ font-size: 28px; }}
        }}
    </style>
</head>
<body>
    <div class='email-container'>
        <div class='header'>
            <div class='icon-transaction'>💳</div>
            <h1>Retiro Realizado</h1>
        </div>
        
        <div class='content'>
            <div class='greeting'>
                Hola <strong>{nombreCliente}</strong>,
            </div>
            
            <p style='color: #4b5563; line-height: 1.6; margin-bottom: 20px;'>
                Tu retiro ha sido procesado exitosamente. A continuación encontrarás los detalles de la transacción:
            </p>
            
            <div class='transaction-card'>
                <div class='transaction-row'>
                    <span class='label'>Tipo de transacción</span>
                    <span class='value'>Retiro</span>
                </div>
                <div class='transaction-row'>
                    <span class='label'>Cuenta</span>
                    <span class='value'>{numeroCuenta}</span>
                </div>
                <div class='transaction-row'>
                    <span class='label'>Fecha y hora</span>
                    <span class='value'>{fecha:dd/MM/yyyy HH:mm}</span>
                </div>
                
                <div class='amount'>
                    - ${monto:N2}
                </div>
            </div>
            
            <div class='balance-section'>
                <div class='balance-label'>Saldo disponible</div>
                <div class='balance-amount'>${saldoActual:N2}</div>
            </div>
            
            <div class='security-notice'>
                <strong>🔒 Aviso de seguridad:</strong> Si no reconoces esta transacción, contacta inmediatamente a nuestro servicio de atención al cliente.
            </div>
        </div>
        
        <div class='footer'>
            <div class='footer-logo'>🏦 Mi Banco</div>
            <p>Este es un correo automático, por favor no responder.</p>
            <p style='margin-top: 10px;'>
                © 2024 Mi Banco. Todos los derechos reservados.
            </p>
        </div>
    </div>
</body>
</html>";
        }

        public async Task<MovimientoResponseDto> ObtenerCuentaAsync(string numeroCuenta)
        {
            var cuenta = await _cuentaDomainRepository.ObtenerPorNumeroCuentaAsync(numeroCuenta);

            if (cuenta == null)
                throw new InvalidOperationException("Cuenta no encontrada");

            var response = _mapper.Map<MovimientoResponseDto>(cuenta);
            return response;
        }
    }
    
}
